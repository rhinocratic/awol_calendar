using CalendarAPI.Model;
using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public class CalendarService : ICalendarService
{
    public IEnumerable<DayEvents> EventsForDateRange(DateOnly startDate, DateOnly endDate)
    {
        throw new NotImplementedException();
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