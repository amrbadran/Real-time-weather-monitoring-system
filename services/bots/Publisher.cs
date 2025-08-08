namespace Real_time_weather_monitoring_system.services.bots;

public class Publisher
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void NotifyAll()
    {
        _subscribers.ForEach(s => s.Update(this));
    }
}