using CalendarAPI.Model.Entity;

namespace CalendarAPI.Model;

public class DayEvents
{
    public DayEvents(IEnumerable<Event> monthEvents, int dayOfMonth)
    {

    }

    public IEnumerable<Event> Events { get; private set; }
}