using FastEndpoints;
using CalendarServer.Model;

namespace CalendarServer.Endpoint;

public class GetEventsEndpoint : Endpoint<GetEventsRequest, GetEventsResponse>
{
    public override void Configure()
    {
        Get("/api/events/{Year}/{Month}/{Day}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEventsRequest req, CancellationToken ct)
    {
        await SendAsync(new GetEventsResponse {Events = []}, cancellation: ct);
    }
}
