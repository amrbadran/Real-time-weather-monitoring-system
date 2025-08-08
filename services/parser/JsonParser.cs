using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.parser;


public class JsonParser : IParser
{
    /// <summary>
    /// Convert Json String To WeatherData Object
    /// </summary>
    /// <param name="weatherData"></param>
    /// <returns>WeatherData Object</returns>
    public WeatherData Parse(string weatherData)
    {
        throw new NotSupportedException();
    }
}