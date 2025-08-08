using System.Text.Json;
using Real_time_weather_monitoring_system.services.parser;

namespace Real_time_weather_monitoring_system.app;

public class App
{
    public static void Run()
    {
        try
        {
            string? input = Console.ReadLine();
            IParser parser = ParserFactory.Create(input);
            var weatherData = parser.Parse(input!);
            
            // Continue On Other Work .....
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("Argument Error");
        }
        catch (JsonException e)
        {
            Console.WriteLine("Can't Convert From Json");
        }
    }
    
}