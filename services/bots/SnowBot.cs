using Real_time_weather_monitoring_system.data;
using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.bots;

/// <summary>
/// Handle SnowBot Logic and check for if this bot will active or not depending on weather input data
/// </summary>
public class SnowBot : ISubscriber, IBot
{
    public Bot Bot
    {
        get => Configuration.Instance.Bots["SnowBot"];
    }

    public string Message()
    {
        return "SnowBot Activated" + (Bot.Message ?? "");
    }

    public string? Update(WeatherData wheatherData)
    {
        throw new NotImplementedException();
    }
}