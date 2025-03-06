
using CalendarAPI.DB;
using CalendarAPI.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace CalendarAPI.Service;

public class CalendarService(CalendarContext calendarContext) : ICalendarService
{
    private readonly CalendarContext _dbContext = calendarContext;

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
        // OnEventUpdated(this, new EventUpdatedEventArgs(evt, UpdateType.DELETE));
        return wasDeleted;
    }

    public async Task<Event?> GetEvent(Guid eventID)
    {
        return await _dbContext.Events.FindAsync(eventID);
    }

    public async Task<Event> CreateOrUpdateEvent(Event evt)
    {
        var entityEntry = _dbContext.Events.Update(evt);
        var wasUpdated = await _dbContext.SaveChangesAsync() == 1;
        // OnEventUpdated(this, new EventUpdatedEventArgs(entityEntry.Entity, UpdateType.SAVE));
        return entityEntry.Entity;
    }
}