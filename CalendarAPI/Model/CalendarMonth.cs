using System.Globalization;
using CalendarAPI.Service;

namespace CalendarAPI.Model;

public class CalendarMonth
{
    private CalendarMonth(IEnumerable<CalendarDay> days, int year, int month, DayOfWeek weekStartDay)
    {
        YearName = year.ToString();
        MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
        DayNames = AbbreviatedDayNames(weekStartDay);
        Days = days;
    }

    public string YearName { get; set; }
    public string MonthName { get; set; }
    public IEnumerable<string> DayNames { get; set; }
    public IEnumerable<CalendarDay> Days { get; set; }

    async public static Task<CalendarMonth> BuildCalendarMonth(ICalendarService calendarService, int year, int month, DayOfWeek weekStartDay = DayOfWeek.Monday)
    {
        var firstDayOfView = new DateOnly(year, month, 1).StartOfWeek(weekStartDay);
        var lastDayOfView = new DateOnly(year, month, DateTime.DaysInMonth(year, month)).EndOfWeek(weekStartDay);
        var numberOfDaysInView = lastDayOfView.DayNumber - firstDayOfView.DayNumber + 1;
        var events = await calendarService.EventsForDateRange(firstDayOfView, lastDayOfView);
        var days = Enumerable.Range(firstDayOfView.DayNumber, numberOfDaysInView)
            .Select(x => DateOnly.FromDayNumber(x))
            .Select(x => new CalendarDay(events, x, month));
        return new CalendarMonth(days, year, month, weekStartDay);
    }

    private static IEnumerable<string> AbbreviatedDayNames(DayOfWeek weekStartDay)
    {
        var days = Enum.GetValues<DayOfWeek>()
            .Select(x => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(x));
        int offset = (int)weekStartDay;
        return days.Skip(offset).Concat(days.Take(offset));
    }
}