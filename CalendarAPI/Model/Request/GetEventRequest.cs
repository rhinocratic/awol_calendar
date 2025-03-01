using FastEndpoints;

namespace CalendarAPI.Model.Request;

public class GetEventRequest
{
    public required Guid ID { get; set; }

    internal sealed class Validator : Validator<GetEventRequest>
    {
        public Validator()
        {

        }
    }
}