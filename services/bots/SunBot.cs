using Real_time_weather_monitoring_system.data;
using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.bots;

/// <summary>
/// Handle SunBot Logic and check for if this bot will active or not depending on weather input data
/// </summary>
public class SunBot : ISubscriber, IBot
{
    public Bot Bot
    {
        get => Configuration.Instance.Bots["SunBot"];
    }

    public string Message()
    {
        return "SunBot Activated" + (Bot.Message ?? "");
    }

    public string? Update(WeatherData wheatherData)
    {
        throw new NotImplementedException();
    }
}