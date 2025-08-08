using System.Xml.Serialization;
using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.parser;

public class XmlParser : IParser
{
    /// <summary>
    /// Convert Xml String To WeatherData Object
    /// </summary>
    /// <param name="weatherData"></param>
    /// <returns>WeatherData Object</returns>
    /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
    /// <exception cref="InvalidOperationException">Thrown when it can't convert the string</exception>
    public WeatherData Parse(string? weatherData)
    {
        if (weatherData == null) throw new ArgumentNullException();
        var serializer = new XmlSerializer(typeof(WeatherData));
        using (StringReader reader = new StringReader(weatherData))
        {
            // If Deserialize returns null then throw InvalidOperationException
            return (WeatherData)(serializer.Deserialize(reader) ?? throw new InvalidOperationException("Can't Convert From Xml"));
        }
    }
}