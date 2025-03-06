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
        Options(b => b.RequireCors(x => x.AllowAnyOrigin()));
    }

    public override async Task HandleAsync(GetEventRequest req, CancellationToken ct)
    {
        var evt = await _calendarService.GetEvent(req.ID);
        if (evt is not null)
        {
            await SendAsync(evt, cancellation: ct);
        }
        await SendNotFoundAsync(ct);
    }
}