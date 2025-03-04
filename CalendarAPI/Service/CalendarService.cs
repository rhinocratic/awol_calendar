
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

    public Event DeleteEvent(Guid eventID)
    {
        throw new NotImplementedException();
    }

    public Event GetEvent(Guid eventID)
    {
        throw new NotImplementedException();
    }

    public Event CreateEvent(Event evt)
    {
        throw new NotImplementedException();
    }

    public Event UpdateEvent(Event modified)
    {
        throw new NotImplementedException();
    }
}