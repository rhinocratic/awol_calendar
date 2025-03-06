// using FastEndpoints;
// using CalendarAPI.Model;
// using CalendarAPI.Service;
// using CalendarAPI.Model.Request;
// using System.Runtime.CompilerServices;
// using CalendarAPI.Model.Entity;

// namespace CalendarAPI.Endpoint;

// public class EventUpdateStreamEndpoint(ICalendarService calendarService) : EndpointWithoutRequest
// {
//     private readonly ICalendarService _calendarService = calendarService;

//     public override void Configure()
//     {
//         Get("event-update-stream");
//         AllowAnonymous();
//         Options(b => b.RequireCors(x => x.AllowAnyOrigin()));
//     }

//     public override async Task HandleAsync(CancellationToken ct)
//     {
//         await SendEventStreamAsync("event-update", GetUpdateStream(ct), cancellation: ct);
//     }

//     private async Task SendUpdate(Event evt)
//     {
//         await SendAsync(evt);
//     }

//     private async IAsyncEnumerable<object?> GetUpdateStream([EnumeratorCancellation] CancellationToken ct)
//     {
//         while (!ct.IsCancellationRequested)
//         {
//             // TODO - return something
//             yield return null;
//         }
//     }


// }