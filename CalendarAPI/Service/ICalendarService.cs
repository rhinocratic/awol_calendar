using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public interface ICalendarService
{
    IEnumerable<Event> MonthEvents(DateOnly date);
    Event SaveEvent(Event evt);
    Event GetEvent(Guid eventID);
    Event UpdateEvent(Event modified);
    Event DeleteEvent(Guid eventID);
}