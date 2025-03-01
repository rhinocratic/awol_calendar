using CalendarAPI.Model.Entity;

namespace CalendarAPI.Service;

public interface ICalendarService
{
    Task<IEnumerable<Event>> EventsForDateRange(DateOnly startDate, DateOnly endDate);
    Task<Event> CreateEvent(Event evt);
    Task<Event?> GetEvent(Guid eventID);
    Task<bool> UpdateEvent(Event modified);
    Task<bool> DeleteEvent(Guid eventID);
}