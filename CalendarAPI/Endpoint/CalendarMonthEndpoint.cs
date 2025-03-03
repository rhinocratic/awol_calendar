using FastEndpoints;
using CalendarAPI.Model;

namespace CalendarAPI.Endpoint;

public class CalendarMonthEndpoint : Endpoint<CalendarMonthRequest, CalendarMonthResponse>
{
    public override void Configure()
    {
        Get("/api/events/{Year}/{Month}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CalendarMonthRequest req, CancellationToken ct)
    {
        await SendAsync(new CalendarMonthResponse { Month = new CalendarMonth(req.Year, req.Month) }, cancellation: ct);
    }
}
