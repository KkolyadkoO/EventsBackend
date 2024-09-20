using EventApp.Core.Models;

namespace EventApp.DataAccess.Repositories;

public interface IEventsRepository
{
    Task<List<Event>> Get();
    Task<Event?> GetById(Guid id);
    Task<Event?> GetByTitle(string title);

    Task<(List<Event?>, int)> GetByFilters(string? title, string? location, DateTime? startDate,
        DateTime? endDate, Guid? categoryId, Guid? userId, int? page, int? size);

    Task<List<Event>> GetByPage(int page, int size);
    Task<Guid> Create(Event receivedEvent);

    Task<Guid> Update(Guid id, string title, string location, DateTime date, Guid category, string description,
        int maxNumberOfMembers, string imageUrl);

    Task<Guid> Delete(Guid id);
}