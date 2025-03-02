using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public class CalendarService : ICalendarService
{
    public Event DeleteEvent(Guid eventID)
    {
        throw new NotImplementedException();
    }

    public Event GetEvent(Guid eventID)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Event> ListEventsForDay(int year, int month, int day)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Event> ListEventsForMonth(int year, int month)
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