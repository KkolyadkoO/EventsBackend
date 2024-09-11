using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using EventApp.Core.Abstractions;
using EventApp.Core.Exceptions;
using EventApp.Core.Models;
using EventApp.Application;
using EventApp.DataAccess.Repositories;
using EventApp.Infrastructure;
using Microsoft.AspNetCore.Identity;

public class UserServiceTests
{
    private readonly Mock<IPasswordHasher> _passwordHasherMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly UserService _userService;
    

    public UserServiceTests()
    {
        _passwordHasherMock = new Mock<IPasswordHasher>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userRepositoryMock = new Mock<IUserRepository>();
        
        _unitOfWorkMock.Setup(u => u.Users).Returns(_userRepositoryMock.Object);
        _userService = new UserService(_passwordHasherMock.Object, _unitOfWorkMock.Object);

    }

    [Fact]
    public async Task Register_CreatesUserAndCommitsTransaction()
    {
        // Arrange
        var username = "testUser";
        var email = "test@example.com";
        var password = "password";
        var role = "user";
        var hashedPassword = "hashedPassword";

        _passwordHasherMock.Setup(ph => ph.HashPassword(password)).Returns(hashedPassword);

        // Act
        await _userService.Register(username, email, password, role);

        // Assert
        _userRepositoryMock.Verify(repo => repo.Create(It.Is<User>(u =>
            u.UserName == username && u.UserEmail == email && u.Password == hashedPassword && u.Role == role)), Times.Once);
        _unitOfWorkMock.Verify(u => u.Complete(), Times.Once);
    }

    [Fact]
    public async Task Login_ReturnsUser_WhenCredentialsAreValid()
    {
        // Arrange
        var username = "testuser";
        var password = "testpassword";
        var hashedPassword = "hashedTestPassword";  // Это хэшированный пароль
        var user = new User(Guid.NewGuid(), username, "testuser@example.com", hashedPassword, "user");

        _userRepositoryMock
            .Setup(r => r.GetByLogin(It.IsAny<string>()))
            .ReturnsAsync(user);

        _passwordHasherMock
            .Setup(h => h.VerifyHashedPassword(user.Password, password))  // Проверка хэша пароля
            .Returns(true);

        // Act
        var result = await _userService.Login(username, password);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(username, result.UserName);
        _userRepositoryMock.Verify(r => r.GetByLogin(It.IsAny<string>()), Times.Once);
        _passwordHasherMock.Verify(h => h.VerifyHashedPassword(user.Password, password), Times.Once);
    }

    [Fact]
    public async Task Login_ThrowsInvalidLoginException_WhenPasswordIsInvalid()
    {
        // Arrange
        var username = "testuser";
        var password = "testpassword";
        var hashedPassword = "hashedTestPassword";
        var user = new User(Guid.NewGuid(), username, "testuser@example.com", "hashedTestPasswordddd", "user");

        _userRepositoryMock
            .Setup(r => r.GetByLogin(It.IsAny<string>()))
            .ReturnsAsync(user);

        _passwordHasherMock
            .Setup(h => h.VerifyHashedPassword(user.Password, password))
            .Returns(false);  // Возвращаем false, если пароли не совпадают

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidLoginException>(() => _userService.Login(username, password));
        Assert.Equal("Invalid password", exception.Message);
        _userRepositoryMock.Verify(r => r.GetByLogin(It.IsAny<string>()), Times.Once);
        _passwordHasherMock.Verify(h => h.VerifyHashedPassword(user.Password, password), Times.Once);
    }

    [Fact]
    public async Task Login_ThrowsInvalidOperationException_WhenUserNotFound()
    {
        // Arrange
        var username = "nonExistentUser";
        var password = "password";

        _passwordHasherMock.Setup(ph => ph.HashPassword(password)).Returns("hashedPassword");
        _userRepositoryMock.Setup(repo => repo.GetByLogin(username)).ThrowsAsync(new InvalidOperationException("User not found"));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _userService.Login(username, password));
        Assert.Equal("User not found", exception.Message);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsListOfUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User(Guid.NewGuid(), "User1", "user1@example.com", "password1", "user"),
            new User(Guid.NewGuid(), "User2", "user2@example.com", "password2", "admin")
        };

        _userRepositoryMock.Setup(repo => repo.Get()).ReturnsAsync(users);

        // Act
        var result = await _userService.GetAllUsers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("User1", result[0].UserName);
        Assert.Equal("User2", result[1].UserName);
    }

    [Fact]
    public async Task Register_ThrowsException_WhenRepositoryThrows()
    {
        // Arrange
        var username = "testUser";
        var email = "test@example.com";
        var password = "password";
        var role = "user";

        _passwordHasherMock.Setup(ph => ph.HashPassword(password)).Returns("hashedPassword");
        _userRepositoryMock.Setup(repo => repo.Create(It.IsAny<User>())).ThrowsAsync(new InvalidOperationException("Test exception"));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _userService.Register(username, email, password, role));
        Assert.Equal("Test exception", exception.Message);
    }
}
