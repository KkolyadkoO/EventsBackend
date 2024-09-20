using EventApp.Application;
using EventApp.Contracts;
using EventApp.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventsService _eventsService;

    public EventsController(IEventsService eventsService)
    {
        _eventsService = eventsService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EventsResponse>> GetEventById(Guid id)
    {
        var foundEvent = await _eventsService.GetEventById(id);
        var response = new EventsResponse(foundEvent.Id, foundEvent.Title, foundEvent.Description,
            foundEvent.Date, foundEvent.Location, foundEvent.CategoryId, foundEvent.MaxNumberOfMembers,
            foundEvent.Members.Count, foundEvent.ImageUrl);
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<List<EventsResponse>>> GetAllEvents()
    {
        var events = await _eventsService.GetAllEvents();
        var response = events.Select(e => new EventsResponse(e.Id, e.Title, e.Description, e.Date
            , e.Location, e.CategoryId, e.MaxNumberOfMembers, e.Members.Count, e.ImageUrl));

        return Ok(response);
    }

    [HttpGet("filter/")]
    public async Task<ActionResult<List<EventsResponse>>> GetFilterEvents([FromQuery] EventFilterRequest filterRequest)
    {
        var events = await _eventsService.GetEventByFilters(filterRequest.Title, filterRequest.Location,
            filterRequest.StartDate, filterRequest.EndDate, filterRequest.Category, filterRequest.page, filterRequest.pageSize);
        var response = events.Select(e => new EventsResponse(e.Id, e.Title, e.Description, e.Date
            , e.Location, e.CategoryId, e.MaxNumberOfMembers, e.Members.Count, e.ImageUrl));

        return Ok(response);
    }

    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<Guid>> CreateEvent(EventsRequest request)
    {
        var newEvent = new Event(Guid.NewGuid(), request.Title, request.Description, request.Date.ToUniversalTime(),
            request.Location, request.CategoryId, request.maxNumberOfMembers, new List<MemberOfEvent>(),
            request.ImageUrl);
        try
        {
            await _eventsService.AddEvent(newEvent);
            return Ok(newEvent.Id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<Guid>> UpdateEvent(Guid id, EventsRequest request)
    {
        try
        {
            return await _eventsService.UpdateEvent(id, request.Title, request.Location, request.Date.ToUniversalTime(),
                request.CategoryId, request.Description, request.maxNumberOfMembers, request.ImageUrl);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<Guid>> DeleteEvent(Guid id)
    {
        return await _eventsService.DeleteEvent(id);
    }
}