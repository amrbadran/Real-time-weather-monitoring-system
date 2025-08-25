using Real_time_weather_monitoring_system.data;
using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.bots;

/// <summary>
/// Handle RainBot Logic and check for if this bot will active or not depending on weather input data
/// </summary>
public class RainBot : ISubscriber, IBot
{
    private Configuration _configuration;
    public RainBot(Configuration configuration)
    {
        _configuration = configuration;
    }

    public Bot? Bot
    {
        get => _configuration.Bots.GetValueOrDefault("RainBot");
    }

    public string Message()
    {
        return "RainBot Activated\nRainBot: " + (Bot?.Message ?? "");
    }

    public string? Update(WeatherData weatherData)
    {
        // If this bot not exists return null
        if (Bot is null) return null;

        // If Either of values null then this condition will be false automatically
        if (Bot.Value.HumidityThreshold < weatherData.Humidity)
            return Message();
        
        return null;
    }
}