using CalendarAPI.Model.Entity;
using Microsoft.VisualBasic;

namespace CalendarAPI.Model;

public class DayEvents
{
    public DayEvents(IEnumerable<Event> events, DateOnly date)
    {
        DayOfMonth = date.Day;
        var day = new DateTimeRange(date.ToDateTime(TimeOnly.MinValue), date.ToDateTime(TimeOnly.MaxValue));
        Events = events.Where(x => x.Interval.Overlaps(day));
    }

    public int DayOfMonth { get; private set; }
    public IEnumerable<Event> Events { get; private set; }
}