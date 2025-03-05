using CalendarAPI.Model.Entity;
using FastEndpoints;

namespace CalendarAPI.Model.Request;

public class UpdateEventRequest
{
    public required Event Event { get; set; }

    internal sealed class Validator : Validator<UpdateEventRequest>
    {
        public Validator()
        {

        }
    }
}