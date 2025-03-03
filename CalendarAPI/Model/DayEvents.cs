using CalendarAPI.Model.Entity;
using Microsoft.VisualBasic;

namespace CalendarAPI.Model;

public class DayEvents
{
    public DayEvents(IEnumerable<Event> events, DateOnly date)
    {
        DayOfMonth = date.Day;
        var dayStart = date.ToDateTime(TimeOnly.MinValue);
        var dayEnd = date.ToDateTime(TimeOnly.MaxValue);
        var day = new DateTimeRange(dayStart, dayEnd);
        Events = events.Where(x => x.Interval.Overlaps(day))
            .Select(x => TruncateToDay(x, dayStart, dayEnd));
    }

    private Event TruncateToDay(Event evt, DateTime dayStart, DateTime dayEnd)
    {
        var truncated = evt;
        var start = (dayStart <= evt.Interval.Start.B && <= dayEnd) ? evt.Interval.Start : dayStart;
        truncated.Interval = new DateTimeRange(date.ToDateTime(TimeOnly.MinValue)
    }

    public int DayOfMonth { get; private set; }
    public IEnumerable<Event> Events { get; private set; }
}