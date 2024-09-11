using AutoMapper;
using EventApp.Core.Models;
using EventApp.DataAccess;
using EventApp.DataAccess.Entities;
using EventApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace EventApp.Tests.Repositories
{
    public class CategoryOfEventsRepositoryTests : IDisposable
    {
        private readonly EventAppDbContext _dbContext;
        private readonly CategoryOfEventsRepository _repository;

        public CategoryOfEventsRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<EventAppDbContext>()
                .UseSqlite("DataSource=:memory:") // Use SQLite In-Memory database
                .Options;

            _dbContext = new EventAppDbContext(options);
            _dbContext.Database.OpenConnection();
            _dbContext.Database.EnsureCreated();

            // You can use dependency injection if necessary, e.g., in a real application scenario
        }

        public void Dispose()
        {
            _dbContext.Database.CloseConnection();
            _dbContext.Dispose();
        }

        [Fact]
        public async Task Get_ShouldReturnMappedCategoryOfEvents()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var categoryOfEventEntities = new List<CategoryOfEventEntity>
            {
                new CategoryOfEventEntity { Id = Guid.NewGuid(), Title = "Category1" },
                new CategoryOfEventEntity { Id = Guid.NewGuid(), Title = "Category2" }
            };

            _dbContext.CategoryOfEventEntities.AddRange(categoryOfEventEntities);
            await _dbContext.SaveChangesAsync();

            var categoryOfEvents = new List<CategoryOfEvent>
            {
                new CategoryOfEvent(Guid.NewGuid(), "Category1"),
                new CategoryOfEvent(Guid.NewGuid(), "Category2")
            };

            mapperMock.Setup(m => m.Map<List<CategoryOfEvent>>(categoryOfEventEntities)).Returns(categoryOfEvents);

            var repository = new CategoryOfEventsRepository(_dbContext, mapperMock.Object);

            // Act
            var result = await repository.Get();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Category1", result[0].Title);
            Assert.Equal("Category2", result[1].Title);
        }

        [Fact]
        public async Task GetById_ShouldReturnMappedCategoryOfEvent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var categoryOfEventEntity = new CategoryOfEventEntity { Id = id, Title = "Category1" };

            _dbContext.CategoryOfEventEntities.Add(categoryOfEventEntity);
            await _dbContext.SaveChangesAsync();

            var categoryOfEvent = new CategoryOfEvent(id, "Category1");

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<CategoryOfEvent>(categoryOfEventEntity)).Returns(categoryOfEvent);

            var repository = new CategoryOfEventsRepository(_dbContext, mapperMock.Object);

            // Act
            var result = await repository.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Category1", result.Title);
        }

        [Fact]
        public async Task Add_ShouldAddNewCategoryOfEvent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var title = "NewCategory";

            var mapperMock = new Mock<IMapper>();
            var repository = new CategoryOfEventsRepository(_dbContext, mapperMock.Object);

            // Act
            var result = await repository.Add(id, title);

            // Assert
            var category = await _dbContext.CategoryOfEventEntities.FindAsync(result);
            Assert.NotNull(category);
            Assert.Equal(title, category.Title);
        }

        [Fact]
        public async Task Add_ShouldThrowException_WhenTitleAlreadyExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var title = "DuplicateCategory";
            _dbContext.CategoryOfEventEntities.Add(new CategoryOfEventEntity { Id = Guid.NewGuid(), Title = title });
            await _dbContext.SaveChangesAsync();

            var mapperMock = new Mock<IMapper>();
            var repository = new CategoryOfEventsRepository(_dbContext, mapperMock.Object);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => repository.Add(id, title));
            Assert.Contains("Category with the same title already exists", ex.Message);
        }

        [Fact]
        public async Task Delete_ShouldRemoveCategoryOfEvent()
        {
            // Arrange
            var id = Guid.NewGuid();
            _dbContext.CategoryOfEventEntities.Add(new CategoryOfEventEntity { Id = id, Title = "CategoryToDelete" });
            await _dbContext.SaveChangesAsync();

            var mapperMock = new Mock<IMapper>();
            var repository = new CategoryOfEventsRepository(_dbContext, mapperMock.Object);

            // Act
            var result = await repository.Delete(id);

            // Assert
            Assert.Equal(id, result);
            var category = await _dbContext.CategoryOfEventEntities.FindAsync(id);
            Assert.Null(category); // Ensure the category has been removed
        }
    }
}
