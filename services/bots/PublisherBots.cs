using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.bots;

public class PublisherBots
{
    private List<ISubscriber> _subscribers;

    private WeatherData _weatherData;

    public PublisherBots(WeatherData weatherData)
    {
        _weatherData = weatherData;
        _subscribers = new List<ISubscriber>();
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public List<string?> NotifyAll()
    {
        return _subscribers
            .Select(s => s.Update(_weatherData))
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToList();
    }
}