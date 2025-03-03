namespace CalendarAPI.Model.Entity;

public class Event
{
    public Guid ID { get; set; }
    public required string Name { get; set; }
    public required DateTimeRange Interval { get; set; }
    public string? Description { get; set; }

    public Event TruncateIntervalTo(DateTimeRange range)
    {
        var start = (range.Start <= Interval.Start) ? Interval.Start : range.Start;
        var end = (Interval.End <= range.End) ? Interval.End : range.End;
        return new Event
        {
            ID = this.ID,
            Name = this.Name,
            Interval = new DateTimeRange(start, end),
            Description = this.Description
        };
    }
}