using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public interface ICalendarService
{
    Task<IEnumerable<Event>> EventsForDateRange(DateOnly startDate, DateOnly endDate);
    Task<Event?> GetEvent(Guid eventID);
    Task<Event> CreateOrUpdateEvent(Event modified);
    Task<bool> DeleteEvent(Guid eventID);
}