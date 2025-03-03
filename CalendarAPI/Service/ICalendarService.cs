using CalendarAPI.Model;
using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public interface ICalendarService
{
    IEnumerable<DayEvents> EventsForDateRange(DateOnly startDate, DateOnly endDate);
    Event SaveEvent(Event evt);
    Event GetEvent(Guid eventID);
    Event UpdateEvent(Event modified);
    Event DeleteEvent(Guid eventID);
}