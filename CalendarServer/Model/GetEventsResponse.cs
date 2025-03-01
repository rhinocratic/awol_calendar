using CalendarServer.Model.Entity;

namespace CalendarServer.Model;

public class GetEventsResponse
{
    public required IEnumerable<Event> Events { get; set;}
}

