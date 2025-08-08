namespace Real_time_weather_monitoring_system.services.parser;

public class ParserFactory
{
    private static Dictionary<char, Func<IParser>> _mapOfParsers = new()
    {
        { '{', () => new JsonParser() },
        { '<', () => new XmlParser() }
    };

    public static IParser Create(string? weatherData)
    {
        if (string.IsNullOrWhiteSpace(weatherData)) 
            throw new InvalidOperationException("Data Can't Be Null");

        char ch = weatherData.TrimStart()[0];

        // Try to get the Func if it is not there then data not valid
        var parser = _mapOfParsers.GetValueOrDefault(ch)
                     ?? throw new InvalidOperationException("Data Is not Valid");

        return parser();
    }
}