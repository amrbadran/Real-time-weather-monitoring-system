namespace Real_time_weather_monitoring_system.models;

public record WeatherData(
    string? Location,
    double? Temperature,
    double? Humidity
);