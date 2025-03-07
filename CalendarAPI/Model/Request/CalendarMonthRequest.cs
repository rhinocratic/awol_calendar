using FastEndpoints;
using FluentValidation;

namespace CalendarAPI.Model.Request;

public class CalendarMonthRequest
{
    public required int Year { get; set; }
    public required int Month { get; set; }
}
