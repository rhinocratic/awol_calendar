using CalendarAPI.Model.Entity;
using FastEndpoints;

namespace CalendarAPI.Model.Request;

public class CreateEventRequest
{
    public required Event Event { get; set; }

    internal sealed class Validator : Validator<CreateEventRequest>
    {
        public Validator()
        {

        }
    }
}