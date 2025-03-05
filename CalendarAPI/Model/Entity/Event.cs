using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarAPI.Model.Entity;

public class Event
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ID { get; set; }
    public required string Title { get; set; }
    public required DateTimeRange Interval { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }

    public Event TruncateIntervalTo(DateTimeRange range)
    {
        var start = (range.Start <= Interval.Start) ? Interval.Start : range.Start;
        var end = (Interval.End <= range.End) ? Interval.End : range.End;
        return new Event
        {
            ID = this.ID,
            Title = this.Title,
            Interval = new DateTimeRange(start, end),
            Description = this.Description,
            Location = this.Location
        };
    }
}