using CalendarAPI.Model;

namespace CalendarAPI.Model;

public class MonthEventsResponse
{
    public required IEnumerable<DayEvents> Events { get; set; }
}

