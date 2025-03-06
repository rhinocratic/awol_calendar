namespace CalendarAPI.Service;

public interface IEventUpdateService
{
    void OnEventUpdated(object source, EventUpdatedEventArgs args);
}