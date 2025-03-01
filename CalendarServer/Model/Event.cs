namespace CalendarServer.Model;

public class Event
{
    public required Guid ID {get; set;}
    public required string Name {get; set;}
    public required DateTimeRange Interval {get; set;}
    public string? Description {get; set;}
}