
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
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<Event?> GetEvent(Guid eventID)
    {
        return await _dbContext.Events.FindAsync(eventID);
    }

    public async Task<Event> CreateEvent(Event evt)
    {
        _dbContext.Events.Add(evt);
        await _dbContext.SaveChangesAsync();
        return evt;
    }

    public async Task<bool> UpdateEvent(Event evt)
    {
        var updated = _dbContext.Events.Update(evt);
        return await _dbContext.SaveChangesAsync() == 1;
    }
}