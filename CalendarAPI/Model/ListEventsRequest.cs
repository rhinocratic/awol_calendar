using FastEndpoints;
using FluentValidation;

namespace CalendarAPI.Model;

public class ListEventsRequest
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int? Day { get; set; }
    // public Tuple<int> YMD { get; set; }

    internal sealed class Validator : Validator<ListEventsRequest>
    {
        public Validator()
        {

        }
    }
}
