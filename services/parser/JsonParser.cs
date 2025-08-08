using System.Text.Json;
using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.parser;


public class JsonParser : IParser
{
    /// <summary>
    /// Convert Json String To WeatherData Object
    /// </summary>
    /// <param name="weatherData"></param>
    /// <returns>WeatherData Object</returns>
    /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
    /// <exception cref="JsonException">Thrown when it can't convert the string</exception>
    public WeatherData Parse(string weatherData)
    {
        if (weatherData == null) throw new ArgumentNullException();
        return JsonSerializer.Deserialize<WeatherData?>(weatherData) ?? throw new JsonException("Can't Convert From Json");
        
    }
}