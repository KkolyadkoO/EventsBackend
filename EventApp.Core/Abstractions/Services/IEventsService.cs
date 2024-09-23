using EventApp.Core.Models;

namespace EventApp.Application;

public interface IEventsService
{
    Task<List<Event>> GetAllEvents();
    Task<Event?> GetEventById(Guid id);
    Task<Event?> GetEventByTitle(string title);

    Task<(List<Event?>, int)> GetEventByFilters(string? title, Guid? locationId, DateTime? startDate,
        DateTime? endDate, Guid? category, Guid? userId, int? page, int? size);

    Task<List<Event>> GetEventByPage(int page, int size);
    Task<Guid> AddEvent(Event receivedEvent);

    Task<Guid> UpdateEvent(Guid id, string title, Guid location, DateTime date, Guid category,
        string description, int maxNumberOfMembers, string imageUrl);

    Task<Guid> DeleteEvent(Guid id);
}