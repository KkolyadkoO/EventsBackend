using EventApp.Core.Models;

namespace EventApp.Application;

public interface IEventsService
{
    Task<List<Event>> GetAllEvents();
    Task<Event?> GetEventById(Guid id);
    Task<Event?> GetEventByTitle(string title);
    Task<List<Event?>> GetEventByFilters(string? title,string? location, DateTime? startDate, DateTime? endDate, Guid? category);
    Task<List<Event>> GetEventByPage(int page, int size);
    Task<Guid> AddEvent(Event receivedEvent);
    Task<Guid> UpdateEvent(Guid id, string title, string location, DateTime date, Guid category,
        string description, int maxNumberOfMembers, string imageUrl);
    Task<Guid> DeleteEvent(Guid id);
}