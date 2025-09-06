namespace Real_time_weather_monitoring_system.models;

public record struct Bot(
    bool? Enabled,
    double? HumidityThreshold,
    double? TemperatureThreshold,
    string? Message
);