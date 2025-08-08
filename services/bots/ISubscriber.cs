using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.bots;

public interface ISubscriber
{
    string? Update(WeatherData weatherData);
}