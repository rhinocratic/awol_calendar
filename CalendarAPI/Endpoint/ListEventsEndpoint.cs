using FastEndpoints;
using CalendarAPI.Model;

namespace CalendarAPI.Endpoint;

public class GetEventsEndpoint : Endpoint<ListEventsRequest, ListEventsResponse>
{
    public override void Configure()
    {
        Get("/api/events/{Year}/{Month}/{Day}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ListEventsRequest req, CancellationToken ct)
    {
        await SendAsync(new ListEventsResponse { Events = [] }, cancellation: ct);
    }
}
