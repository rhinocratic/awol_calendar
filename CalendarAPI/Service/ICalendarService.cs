using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public interface ICalendarService
{
    IEnumerable<Event> ListEventsForMonth(int year, int month);
    IEnumerable<Event> ListEventsForDay(int year, int month, int day);
    Event SaveEvent(Event evt);
    Event GetEvent(Guid eventID);
    Event UpdateEvent(Event modified);
    Event DeleteEvent(Guid eventID);
}