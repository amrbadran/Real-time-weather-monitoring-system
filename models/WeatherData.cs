using System.Xml.Serialization;

namespace Real_time_weather_monitoring_system.models;

[XmlRoot("WeatherData")]
public record struct WeatherData(
    [XmlElement("Location")] string? Location,
    [XmlElement("Temperature")] double? Temperature,
    [XmlElement("Humidity")] double? Humidity
);