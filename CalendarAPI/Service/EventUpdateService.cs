using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public enum UpdateType { SAVE, DELETE };

public class EventUpdatedEventArgs(Event evt, UpdateType type) : EventArgs
{
    public readonly Event Event = evt;
    public readonly string? Type = Enum.GetName(type);
}

public class EventUpdateService : IEventUpdateService
{
    public event EventHandler<EventUpdatedEventArgs> EventUpdated;

    private TaskCompletionSource<EventUpdatedEventArgs> _tcs;

    EventUpdateService()
    {
        _tcs = new TaskCompletionSource<EventUpdatedEventArgs>();
        EventUpdated += UpdateOccured;
    }
    public virtual void OnEventUpdated(object source, EventUpdatedEventArgs args)
    {
        EventUpdated.Invoke(source, args);
    }

    public void UpdateOccured(object? source, EventUpdatedEventArgs args)
    {
        _tcs.SetResult(args);
    }

    public Task<EventUpdatedEventArgs> GetNextUpdate()
    {
        return _tcs.Task;
    }

}