using System.Collections.ObjectModel;
using Real_time_weather_monitoring_system.models;

namespace Real_time_weather_monitoring_system.data;

/// <summary>
/// Configuration class that will be handling the bots config info from config.json file
/// This class apply singleton pattern, any class want to get config.json can get to it through this file
/// </summary>
public sealed class Configuration
{
    private static readonly Lazy<Configuration> Lazy = new Lazy<Configuration>(() => new Configuration());

    public readonly ReadOnlyDictionary<string, Bot> Bots;

    public static Configuration Instance
    {
        get => Lazy.Value;
    }

    private Configuration()
    {
        Bots = Load();
    }

    /// <summary>
    /// This function loads json data from config.json
    /// Deserialize them into dictionary
    /// </summary>
    /// <returns>Readonly dictionary for all bots</returns>
    private ReadOnlyDictionary<string, Bot> Load()
    {
        throw new NotSupportedException();
    }
}