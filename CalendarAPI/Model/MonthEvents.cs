using System.Globalization;
using System.Linq;
using CalendarAPI.Service;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.VisualBasic;

namespace CalendarAPI.Model;

public class MonthEvents
{
    public MonthEvents(ICalendarService calendarService, DateOnly date, DayOfWeek weekStartDay = DayOfWeek.Monday)
    {
        YearName = date.Year.ToString();
        MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);
        DayNames = AbbreviatedDayNames(weekStartDay);
        var firstDayOfView = date.FirstOfMonth().StartOfWeek(weekStartDay).DayNumber;
        var lastDayOfView = date.LastOfMonth().EndOfWeek(weekStartDay).DayNumber;
        DayEvents = Enumerable.Range(firstDayOfView, lastDayOfView)
            .Select(x => new Model.DayEvents())
    }

    private static IEnumerable<string> AbbreviatedDayNames(DayOfWeek weekStartDay)
    {
        var days = Enum.GetValues<DayOfWeek>()
            .Select(x => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(x));
        int offset = (int)weekStartDay;
        return days.Skip(offset).Concat(days.Take(offset));
    }

    public string YearName { get; set; }
    public string MonthName { get; set; }
    public IEnumerable<string> DayNames { get; set; }
    public IEnumerable<DayEvents> Days { get; set; }
}