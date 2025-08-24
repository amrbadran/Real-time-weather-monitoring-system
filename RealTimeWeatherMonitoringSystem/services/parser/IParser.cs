using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.parser;

public interface IParser
{
    WeatherData Parse(string s);
}