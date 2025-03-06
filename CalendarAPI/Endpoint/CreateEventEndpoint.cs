using FastEndpoints;
using CalendarAPI.Service;
using CalendarAPI.Model.Request;
using CalendarAPI.Model.Entity;

namespace CalendarAPI.Endpoint;

public class CreateEventEndpoint(ICalendarService calendarService) : Endpoint<Event>
{
    private readonly ICalendarService _calendarService = calendarService;

    public override void Configure()
    {
        Post("/api/events");
        AllowAnonymous();
        Options(b => b.RequireCors(x => x.AllowAnyOrigin()));
    }

    public override async Task HandleAsync(Event req, CancellationToken ct)
    {
        var created = await _calendarService.CreateEvent(req);
        await SendCreatedAtAsync<GetEventEndpoint>(routeValues: new { id = created.ID }, responseBody: null, cancellation: ct);
    }

}