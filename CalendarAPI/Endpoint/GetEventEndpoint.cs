using FastEndpoints;
using CalendarAPI.Model.Entity;
using CalendarAPI.Service;
using CalendarAPI.Model.Request;

namespace CalendarAPI.Endpoint;

public class GetEventEndpoint(ICalendarService calendarService) : Endpoint<GetEventRequest, Event>
{
    private readonly ICalendarService _calendarService = calendarService;

    public override void Configure()
    {
        Get("/api/events/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEventRequest req, CancellationToken ct)
    {
        var evt = await _calendarService.GetEvent(req.ID);
        await SendAsync(evt, cancellation: ct);
    }
}