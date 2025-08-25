using System.Collections.ObjectModel;
using System.Text.Json;
using Real_time_weather_monitoring_system.models;
using Real_time_weather_monitoring_system.utils;

namespace Real_time_weather_monitoring_system.data;

/// <summary>
/// Configuration class that will be handling the bots config info from config.json file
/// </summary>
public class Configuration
{
    public readonly ReadOnlyDictionary<string, Bot> Bots;

    public Configuration(IConfigFileReader reader)
    {
        Bots = Load(reader);
    }

    /// <summary>
    /// This function loads json data from config.json
    /// Deserialize them into dictionary
    /// </summary>
    /// <returns>Readonly dictionary for all bots</returns>
    /// <exception cref="JsonException">throws when fail to convert the file</exception>
    private ReadOnlyDictionary<string, Bot> Load(IConfigFileReader reader)
    {
        var file = reader.ReadAllText(Constants.ConfigPath);

        var dict = JsonSerializer.Deserialize<Dictionary<string, Bot>>(file, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        if (dict == null) throw new JsonException();
        
        return new ReadOnlyDictionary<string, Bot>(dict);
    }
}

