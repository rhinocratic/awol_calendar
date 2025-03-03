using CalendarAPI.Model.Entity;

namespace CalendarAPI.Model;

public class MonthEventsResponse
{
    public required IEnumerable<Event> Events { get; set; }
}

