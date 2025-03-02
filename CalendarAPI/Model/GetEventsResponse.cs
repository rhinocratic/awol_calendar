using CalendarAPI.Model.Entity;

namespace CalendarAPI.Model;

public class GetEventsResponse
{
    public required IEnumerable<Event> Events { get; set;}
}

