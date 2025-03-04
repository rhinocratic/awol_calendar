using FastEndpoints;
using CalendarAPI.Model;
using CalendarAPI.Service;
using CalendarAPI.Model.Request;

namespace CalendarAPI.Endpoint;

public class CalendarMonthEndpoint(ICalendarService calendarService) : Endpoint<CalendarMonthRequest, CalendarMonth>
{
    private readonly ICalendarService _calendarService = calendarService;

    public override void Configure()
    {
        Get("/api/events/{Year}/{Month}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CalendarMonthRequest req, CancellationToken ct)
    {
        var month = await CalendarMonth.BuildCalendarMonth(_calendarService, req.Year, req.Month);
        await SendAsync(month, cancellation: ct);
    }
}
