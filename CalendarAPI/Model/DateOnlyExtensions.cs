namespace CalendarAPI.Model;

public static class DateOnlyExtensions
{
    public static DateOnly StartOfWeek(this DateOnly date, DayOfWeek weekStartDay = DayOfWeek.Monday)
    {
        var offset = -((date.DayOfWeek - weekStartDay + 7) % 7);
        return date.AddDays(offset);
    }

    public static DateOnly EndOfWeek(this DateOnly date, DayOfWeek weekStartDay = DayOfWeek.Monday)
    {
        var offset = (weekStartDay + 6 - date.DayOfWeek) % 7;
        return date.AddDays(offset);
    }
}