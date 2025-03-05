using FastEndpoints;

namespace CalendarAPI.Model.Request;

public class DeleteEventRequest
{
    public required Guid ID { get; set; }

    internal sealed class Validator : Validator<DeleteEventRequest>
    {
        public Validator()
        {

        }
    }
}