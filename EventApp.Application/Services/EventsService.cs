using EventApp.Core.Abstractions;
using EventApp.Core.Exceptions;
using EventApp.Core.Models;
using EventApp.DataAccess.Repositories;

namespace EventApp.Application;

public class EventsService : IEventsService
{
    private readonly IUnitOfWork _unitOfWork;

    public EventsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Event>> GetAllEvents()
    {
        return await _unitOfWork.Events.Get();
    }

    public async Task<Event?> GetEventById(Guid id)
    {
        return await _unitOfWork.Events.GetById(id);
    }

    public async Task<Event?> GetEventByTitle(string title)
    {
        return await _unitOfWork.Events.GetByTitle(title);
    }

    public async Task<List<Event?>> GetEventByFilters(string? title, string? location, DateTime? startDate,
        DateTime? endDate, Guid? category, int? page, int? size)
    {
        return await _unitOfWork.Events.GetByFilters(
            title,
            location, 
            startDate, 
            endDate, 
            category,
            page,
            size
        );
    }

    public async Task<List<Event>> GetEventByPage(int page, int size)
    {
        return await _unitOfWork.Events.GetByPage(page, size);
    }

    public async Task<Guid> AddEvent(Event receivedEvent)
    {
        try
        {
            var id = await _unitOfWork.Events.Create(receivedEvent);
            _unitOfWork.Complete();
            return id;
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.Message);
        }
        
    }

    public async Task<Guid> UpdateEvent(Guid id, string title, string location, DateTime date, Guid category,
        string description, int maxNumberOfMembers, string imageUrl)
    {
        try
        {
            return await _unitOfWork.Events.Update(id, title, location, date, category, description, maxNumberOfMembers, imageUrl);
        }
        catch (Exception e)
        {
            throw new InvalidOperationException(e.Message);
        }
    }

    public async Task<Guid> DeleteEvent(Guid id)
    {
        return await _unitOfWork.Events.Delete(id);
    }

   
}