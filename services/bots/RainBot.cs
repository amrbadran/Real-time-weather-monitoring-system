using Real_time_weather_monitoring_system.data;
using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.bots;

/// <summary>
/// Handle RainBot Logic and check for if this bot will active or not depending on weather input data
/// </summary>
public class RainBot : ISubscriber, IBot
{
    public Bot Bot
    {
        get => Configuration.Instance.Bots["RainBot"];
    }
    
    public string Message()
    {
        return "RainBot Activated" + (Bot.Message ?? "");
    }

    public string? Update(WeatherData weatherData)
    {
        throw new NotImplementedException();
    }
}