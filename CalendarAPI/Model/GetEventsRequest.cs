namespace CalendarAPI.Model;

public class GetEventsRequest
{
    public int Year {get; set;}
    public int Month {get; set;}
    public int? Day {get; set;}
}
