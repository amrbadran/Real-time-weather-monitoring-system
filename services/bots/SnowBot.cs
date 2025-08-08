using Real_time_weather_monitoring_system.data;
using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.bots;

/// <summary>
/// Handle SnowBot Logic and check for if this bot will active or not depending on weather input data
/// </summary>
public class SnowBot : ISubscriber, IBot
{
    public Bot? Bot
    {
        get => Configuration.Instance.Bots["SnowBot"];
    }

    public string Message()
    {
        return "SnowBot Activated\nSnowBot: " + (Bot?.Message ?? "");
    }

    public string? Update(WeatherData weatherData)
    {
        // If this bot not exists return null
        if (Bot is null) return null;

        // If Either of values null then this condition will be false automatically
        if (Bot.Value.TemperatureThreshold > weatherData.Temperature)
            return Message();

        return null;
    }
}