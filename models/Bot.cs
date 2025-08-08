namespace Real_time_weather_monitoring_system.models;

public record struct Bot(
    bool? Enabled,
    string? HumidityThreshold,
    string? TemperatureThreshold,
    string? Message
);