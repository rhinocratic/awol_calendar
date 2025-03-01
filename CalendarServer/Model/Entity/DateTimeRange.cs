using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CalendarServer.Model.Entity;

[Owned]
public class DateTimeRange {
    public DateTime Start {get; private set;}
    public DateTime End {get; private set;}

    public DateTimeRange(DateTime start, DateTime end)
    {
        if (start >= end)
        {
            throw new ArgumentException("The start time of DateTimeRange must be strictly earlier than the end time.");
        }
        Start = start;
        End = end;
    }

    public bool Overlaps (DateTimeRange other)
    {
        return Start < other.End && End > other.Start;
    }

    public bool Overlaps(IEnumerable<DateTimeRange> others)
    {
        return others.FirstOrDefault(x => this.Overlaps(x)) is not null;
    }
}