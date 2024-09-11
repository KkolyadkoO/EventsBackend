using Moq;
using Xunit;
using EventApp.Core.Abstractions;
using EventApp.Core.Models;
using EventApp.Application;
using EventApp.DataAccess.Repositories;

public class CategoryOfEventsServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<ICategoryOfEventsRepository> _categoryRepositoryMock;
    private readonly CategoryOfEventsService _categoryOfEventsService;

    public CategoryOfEventsServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _categoryRepositoryMock = new Mock<ICategoryOfEventsRepository>();
        
        _unitOfWorkMock.Setup(u => u.Categories).Returns(_categoryRepositoryMock.Object);
        _categoryOfEventsService = new CategoryOfEventsService(_unitOfWorkMock.Object);
    }

    // Тест для метода GetAllCategoryOfEvents
    [Fact]
    public async Task GetAllCategoryOfEvents_ReturnsListOfCategories()
    {
        // Arrange
        var categories = new List<CategoryOfEvent>
        {
            new CategoryOfEvent( Guid.NewGuid(), "Music" ),
            new CategoryOfEvent( Guid.NewGuid(), "Technology" )
        };

        _categoryRepositoryMock
            .Setup(c => c.Get())
            .ReturnsAsync(categories);

        // Act
        var result = await _categoryOfEventsService.GetAllCategoryOfEvents();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Music", result[0].Title);
        Assert.Equal("Technology", result[1].Title);
    }

    // Тест для метода GetCategoryOfEventById
    [Fact]
    public async Task GetCategoryOfEventById_ReturnsCategory()
    {
        // Arrange
        var category = new CategoryOfEvent (Guid.NewGuid(), "Sports" );

        _categoryRepositoryMock
            .Setup(c => c.GetById(category.Id))
            .ReturnsAsync(category);

        // Act
        var result = await _categoryOfEventsService.GetCategoryOfEventById(category.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(category.Id, result.Id);
        Assert.Equal("Sports", result.Title);
    }

    // Тест для метода GetCategoryOfEventByTitle
    [Fact]
    public async Task GetCategoryOfEventByTitle_ReturnsCategory()
    {
        // Arrange
        var category = new CategoryOfEvent (Guid.NewGuid(), "Arts" );


        _categoryRepositoryMock
            .Setup(c => c.GetByTitle("Arts"))
            .ReturnsAsync(category);

        // Act
        var result = await _categoryOfEventsService.GetCategoryOfEventByTitle("Arts");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Arts", result.Title);
    }

    // Тест для метода AddCategoryOfEvent
    [Fact]
    public async Task AddCategoryOfEvent_AddsCategoryAndReturnsId()
    {
        // Arrange
        var category = new CategoryOfEvent (Guid.NewGuid(), "Science" );


        _categoryRepositoryMock
            .Setup(c => c.Add(category.Id, category.Title))
            .ReturnsAsync(category.Id);

        // Act
        var result = await _categoryOfEventsService.AddCategoryOfEvent(category);

        // Assert
        Assert.Equal(category.Id, result);
        _unitOfWorkMock.Verify(u => u.Complete(), Times.Once); // Проверка, что метод Complete был вызван
    }

    // Тест для метода AddCategoryOfEvent с исключением
    [Fact]
    public async Task AddCategoryOfEvent_ThrowsInvalidOperationException_OnFailure()
    {
        // Arrange
        var category = new CategoryOfEvent (Guid.NewGuid(), "Sports" );


        _categoryRepositoryMock
            .Setup(c => c.Add(It.IsAny<Guid>(), It.IsAny<string>()))
            .ThrowsAsync(new InvalidOperationException("Test exception"));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => 
            _categoryOfEventsService.AddCategoryOfEvent(category));

        Assert.Equal("Failed to add the category: Test exception", exception.Message);
    }

    // Тест для метода UpdateCategoryOfEvent
    [Fact]
    public async Task UpdateCategoryOfEvent_UpdatesCategoryAndReturnsId()
    {
        // Arrange
        var categoryId = Guid.NewGuid();
        var updatedTitle = "Updated Title";

        _categoryRepositoryMock
            .Setup(c => c.Update(categoryId, updatedTitle))
            .ReturnsAsync(categoryId);

        // Act
        var result = await _categoryOfEventsService.UpdateCategoryOfEvent(categoryId, updatedTitle);

        // Assert
        Assert.Equal(categoryId, result);
    }

    // Тест для метода DeleteCategoryOfEvent
    [Fact]
    public async Task DeleteCategoryOfEvent_DeletesCategoryAndReturnsId()
    {
        // Arrange
        var categoryId = Guid.NewGuid();

        _categoryRepositoryMock
            .Setup(c => c.Delete(categoryId))
            .ReturnsAsync(categoryId);

        // Act
        var result = await _categoryOfEventsService.DeleteCategoryOfEvent(categoryId);

        // Assert
        Assert.Equal(categoryId, result);
    }
}
