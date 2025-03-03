using System.Globalization;

namespace CalendarAPI.Model;

public static class DateExtensions
{

    public static DateOnly FirstOfMonth(this DateOnly date)
    {
        return date.AddDays(1 - date.Day);
    }

    public static DateOnly LastOfMonth(this DateOnly date)
    {
        var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
        return date.AddDays(daysInMonth - date.Day);
    }

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