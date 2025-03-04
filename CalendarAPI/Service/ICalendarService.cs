using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public interface ICalendarService
{
    Task<IEnumerable<Event>> EventsForDateRange(DateOnly startDate, DateOnly endDate);
    Event CreateEvent(Event evt);
    Event GetEvent(Guid eventID);
    Event UpdateEvent(Event modified);
    Event DeleteEvent(Guid eventID);
}