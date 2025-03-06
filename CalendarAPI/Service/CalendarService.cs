
using CalendarAPI.DB;
using CalendarAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CalendarAPI.Service;

public enum UpdateType { SAVE, DELETE };

public class EventUpdatedEventArgs(Event evt, UpdateType type) : System.EventArgs
{
    public readonly Event Event = evt;
    public readonly string? Type = Enum.GetName(type);
}

public class CalendarService(CalendarContext calendarContext) : ICalendarService
{
    public event EventHandler? EventUpdated;

    private readonly CalendarContext _dbContext = calendarContext;

    protected virtual void OnEventUpdated(object source, EventUpdatedEventArgs args)
    {
        EventUpdated?.Invoke(source, args);
    }

    public async Task<IEnumerable<Event>> EventsForDateRange(DateOnly startDate, DateOnly endDate)
    {
        var minDateTime = startDate.ToDateTime(TimeOnly.MinValue);
        var maxDateTime = endDate.ToDateTime(TimeOnly.MaxValue);
        return await _dbContext.Events
            .Where(x => x.Interval.End > minDateTime && x.Interval.Start < maxDateTime)
            .ToListAsync();
    }

    public async Task<bool> DeleteEvent(Guid eventID)
    {
        var evt = await _dbContext.Events.FindAsync(eventID);
        if (evt is null)
        {
            return false;
        }
        var entityEntry = _dbContext.Remove(evt);
        var wasDeleted = await _dbContext.SaveChangesAsync() == 1;
        OnEventUpdated(this, new EventUpdatedEventArgs(evt, UpdateType.DELETE));
        return wasDeleted;
    }

    public async Task<Event?> GetEvent(Guid eventID)
    {
        return await _dbContext.Events.FindAsync(eventID);
    }

    public async Task<Event> CreateEvent(Event evt)
    {
        _dbContext.Events.Add(evt);
        await _dbContext.SaveChangesAsync();
        // OnEventUpdated(new EventUpdatedEventArgs(updated, UpdateType.SAVE));
        return evt;
    }

    public async Task<bool> UpdateEvent(Event evt)
    {
        var updated = _dbContext.Events.Update(evt).Entity;
        var wasUpdated = await _dbContext.SaveChangesAsync() == 1;
        OnEventUpdated(this, new EventUpdatedEventArgs(updated, UpdateType.SAVE));
        return wasUpdated;
    }
}