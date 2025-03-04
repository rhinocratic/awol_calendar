using FastEndpoints;
using CalendarAPI.Model;
using CalendarAPI.Service;

namespace CalendarAPI.Endpoint;

public class CalendarMonthEndpoint(ICalendarService calendarService) : Endpoint<CalendarMonthRequest, CalendarMonthResponse>
{
    private readonly ICalendarService _calendarService = calendarService;

    public override void Configure()
    {
        Get("/api/events/{Year}/{Month}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CalendarMonthRequest req, CancellationToken ct)
    {
        var response = new CalendarMonthResponse { Month = new CalendarMonth(_calendarService, req.Year, req.Month) };
        await SendAsync(response, cancellation: ct);
    }
}
