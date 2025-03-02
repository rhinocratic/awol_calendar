using CalendarAPI.Model.Entity;

namespace CalendarAPI.Model;

public class ListEventsResponse
{
    public required IEnumerable<Event> Events { get; set; }
}

