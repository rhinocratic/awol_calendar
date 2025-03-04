using CalendarAPI.DB;
using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public class CalendarService(CalendarContext calendarContext) : ICalendarService
{
    private readonly CalendarContext _dbContext = calendarContext;

    public IEnumerable<Event> EventsForDateRange(DateOnly startDate, DateOnly endDate)
    {
        return _dbContext.Events;
    }

    public Event DeleteEvent(Guid eventID)
    {
        throw new NotImplementedException();
    }

    public Event GetEvent(Guid eventID)
    {
        throw new NotImplementedException();
    }

    public Event SaveEvent(Event evt)
    {
        throw new NotImplementedException();
    }

    public Event UpdateEvent(Event modified)
    {
        throw new NotImplementedException();
    }
}