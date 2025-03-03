using FastEndpoints;
using FluentValidation;

namespace CalendarAPI.Model;

public class MonthEventsRequest
{
    public int Year { get; set; }
    public int Month { get; set; }

    internal sealed class Validator : Validator<MonthEventsRequest>
    {
        public Validator()
        {

        }
    }
}
