using FastEndpoints;
using CalendarAPI.Model;
using CalendarAPI.Service;
using CalendarAPI.Model.Request;
using CalendarAPI.Model.Entity;

namespace CalendarAPI.Endpoint;

public class DeleteEventEndpoint(ICalendarService calendarService) : Endpoint<DeleteEventRequest, bool>
{
    private readonly ICalendarService _calendarService = calendarService;

    public override void Configure()
    {
        Delete("/api/events/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteEventRequest req, CancellationToken ct)
    {
        var evt = await _calendarService.DeleteEvent(req.ID);
        await SendAsync(evt, cancellation: ct);
    }
}