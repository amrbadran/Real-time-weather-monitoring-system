using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.services.bots;

public interface IBot
{
    Bot? Bot{ get; }
    /// <summary>
    /// This function is implemented by IBot interface
    /// It used for logging whether this bot activated
    /// </summary>
    /// <returns>A Message Represented by the bot</returns>
    string Message();
    
}