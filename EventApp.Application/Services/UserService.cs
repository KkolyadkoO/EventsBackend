using EventApp.Core.Abstractions;
using EventApp.Core.Exceptions;
using EventApp.Core.Models;
using EventApp.Infrastructure;

namespace EventApp.Application;

public class UserService : IUserService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
    {
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }
    public async Task Register(string username, string email, string password, string role)
    {
        var hashedPassword = _passwordHasher.HashPassword(password);
        var user = new User(Guid.NewGuid(), username, email, hashedPassword, role);
        await _unitOfWork.Users.Create(user);
        await _unitOfWork.Complete();
    }

    public async Task<User> Login(string username, string password)
    {
        try
        {
            var user = await _unitOfWork.Users.GetByLogin(username);
            if (!_passwordHasher.VerifyHashedPassword(user.Password, password))
            {
                throw new InvalidLoginException("Invalid password");
            }

            return user;
        }
        catch (InvalidOperationException e)
        {
            throw new InvalidOperationException(e.Message);
        }
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _unitOfWork.Users.Get();
        return users;
    }
}