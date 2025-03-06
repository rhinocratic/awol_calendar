using CalendarAPI.Model.Entity;

namespace CalendarAPI.Model;

public class CalendarDay
{
    public CalendarDay(IEnumerable<Event> events, DateOnly date, int month)
    {
        DayOfMonth = date.Day;
        DayNumber = date.DayNumber;
        Enabled = date.Month == month;
        var dayStart = date.ToDateTime(TimeOnly.MinValue);
        var nextDayStart = date.AddDays(1).ToDateTime(TimeOnly.MinValue);
        var day = new DateTimeRange(dayStart, nextDayStart);
        Events = events.Where(x => x.Interval.Overlaps(day))
            .Select(x => x.TruncateIntervalTo(day));
    }

    public int DayOfMonth { get; private set; }
    public int DayNumber { get; private set; }
    public bool Enabled { get; private set; }
    public IEnumerable<Event> Events { get; private set; }
}