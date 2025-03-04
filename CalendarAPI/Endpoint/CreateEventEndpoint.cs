using FastEndpoints;
using CalendarAPI.Service;
using CalendarAPI.Model.Request;

namespace CalendarAPI.Endpoint;

public class CreateEventEndpoint(ICalendarService calendarService) : Endpoint<CreateEventRequest, int>
{
    private readonly ICalendarService _calendarService = calendarService;

    public override void Configure()
    {
        Post("/api/events");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateEventRequest req, CancellationToken ct)
    {
        var month = 42;
        await SendAsync(month, cancellation: ct);
    }

}