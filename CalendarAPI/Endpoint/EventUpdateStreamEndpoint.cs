using FastEndpoints;
using CalendarAPI.Model;
using CalendarAPI.Service;
using CalendarAPI.Model.Request;
using System.Runtime.CompilerServices;
using CalendarAPI.Model.Entity;

namespace CalendarAPI.Endpoint;

public class EventUpdateStreamEndpoint(ICalendarService calendarService) : EndpointWithoutRequest
{
    private readonly ICalendarService _calendarService = calendarService;

    private TaskCompletionSource<EventArgs> _tcs;

    public override void Configure()
    {
        Get("event-update-stream");
        AllowAnonymous();
        Options(b => b.RequireCors(x => x.AllowAnyOrigin()));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendEventStreamAsync("", GetUpdateStream(ct), cancellation: ct);
    }

    private async Task SendUpdate(Event evt)
    {
        await SendAsync(evt);
    }

    private void UpdateOccured(object? source, EventArgs args)
    {
        _tcs?.SetResult(args);
    }

    private async IAsyncEnumerable<object> GetUpdateStream([EnumeratorCancellation] CancellationToken ct)
    {
        _calendarService.EventUpdated += UpdateOccured;
        while (!ct.IsCancellationRequested)
        {
            _tcs = new TaskCompletionSource<EventArgs>();
            await _tcs.Task;
            yield return _tcs.Task.Result;
        }
        _calendarService.EventUpdated -= UpdateOccured;
    }


}