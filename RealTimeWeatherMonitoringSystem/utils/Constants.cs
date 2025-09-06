namespace Real_time_weather_monitoring_system.utils;

public static class Constants
{
    public static readonly string RootPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..");
    public static readonly string ConfigPath = Path.Combine(RootPath, "files", "config.json");
}