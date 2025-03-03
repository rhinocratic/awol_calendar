using FastEndpoints;
using FluentValidation;

namespace CalendarAPI.Model;

public class CalendarMonthRequest
{
    public int Year { get; set; }
    public int Month { get; set; }

    internal sealed class Validator : Validator<CalendarMonthRequest>
    {
        public Validator()
        {

        }
    }
}
