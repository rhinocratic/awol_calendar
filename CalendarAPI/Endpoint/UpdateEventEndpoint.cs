using FastEndpoints;
using CalendarAPI.Model.Entity;
using CalendarAPI.Service;
using CalendarAPI.Model.Request;

namespace CalendarAPI.Endpoint;

public class UpdateEventEndpoint(ICalendarService calendarService) : Endpoint<UpdateEventRequest, bool>
{
    private readonly ICalendarService _calendarService = calendarService;

    public override void Configure()
    {
        Put("/api/events/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateEventRequest req, CancellationToken ct)
    {
        var updated = await _calendarService.UpdateEvent(req.Event);
        await SendAsync(updated, cancellation: ct);
    }
}