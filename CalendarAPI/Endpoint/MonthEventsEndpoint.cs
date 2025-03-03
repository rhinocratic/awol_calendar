using FastEndpoints;
using CalendarAPI.Model;

namespace CalendarAPI.Endpoint;

public class MonthEventsEndpoint : Endpoint<MonthEventsRequest, MonthEventsResponse>
{
    public override void Configure()
    {
        Get("/api/events/{Year}/{Month}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MonthEventsRequest req, CancellationToken ct)
    {
        await SendAsync(new MonthEventsResponse { Events = [] }, cancellation: ct);
    }
}
