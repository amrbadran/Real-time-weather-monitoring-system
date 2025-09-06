using System.Text.Json;
using Real_time_weather_monitoring_system.data;
using Real_time_weather_monitoring_system.models;
using Real_time_weather_monitoring_system.services.bots;
using Real_time_weather_monitoring_system.services.parser;
using Microsoft.Extensions.DependencyInjection;
using Real_time_weather_monitoring_system.utils;

namespace Real_time_weather_monitoring_system.app;

public class App
{
    public static void Run()
    {
        try
        {
            // Run The Ioc For Building Objects
            var provider = IocBuilder.BuildObjects();

            // Seed System by config.json
            BuildConfiguration(provider);

            // Take input and Build WeatherData
            var weatherData = BuildWeatherData(Console.ReadLine());

            // Get PublisherBots Object and Seed it by bots
            var publisherBots = BuildPublisher(weatherData, provider);

            // Notify All bots by their update methods then print their messages
            PrintBotsMessages(publisherBots);
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

    private static PublisherBots BuildPublisher(WeatherData weatherData, ServiceProvider serviceProvider)
    {
        PublisherBots publisherBots = new PublisherBots(weatherData);
        var bots = serviceProvider.GetRequiredService<IEnumerable<ISubscriber>>();

        foreach (var bot in bots)
        {
            publisherBots.Subscribe(bot);
        }

        return publisherBots;
    }

    private static void PrintBotsMessages(PublisherBots publisherBots)
    {
        publisherBots.NotifyAll().ForEach(s => Console.WriteLine(s));
    }

    private static WeatherData BuildWeatherData(string? input)
    {
        IParser parser = ParserFactory.Create(input);
        return parser.Parse(input!);
    }

    /// <summary>
    /// This is for config.json file,
    /// Load config.json to our system By Calling Instance only.
    /// </summary>
    /// <returns>Configuration Object</returns>
    private static Configuration BuildConfiguration(ServiceProvider provider)
    {
        return provider.GetRequiredService<Configuration>();
    }
}