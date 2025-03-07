using FastEndpoints;
using FluentValidation;

namespace CalendarAPI.Model.Request.Validation;
public class CalendarMonthRequestValidator : Validator<CalendarMonthRequest>
{
    private static bool IsValidMonthAndYear(CalendarMonthRequest req)
    {
        try
        {
            var date = new DateOnly(req.Year, req.Month, 1);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public CalendarMonthRequestValidator()
    {
        RuleFor(x => x)
            .Must(IsValidMonthAndYear)
            .WithMessage(x => $"{x.Year}/{x.Month} is not a valid year/month combination.");
    }
}