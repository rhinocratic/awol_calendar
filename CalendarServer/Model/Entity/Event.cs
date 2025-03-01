using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarServer.Model.Entity;

[Table("events")]
public class Event
{
    public Guid ID {get; set;}
    public required string Name {get; set;}
    public required DateTimeRange Interval {get; set;}
    public string? Description {get; set;}
}