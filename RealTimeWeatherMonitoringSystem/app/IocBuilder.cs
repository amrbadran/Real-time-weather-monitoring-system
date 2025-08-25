using Microsoft.Extensions.DependencyInjection;
using Real_time_weather_monitoring_system.data;
using Real_time_weather_monitoring_system.services.bots;

namespace Real_time_weather_monitoring_system.app;

public class IocBuilder
{
    public static ServiceProvider BuildObjects()
    {
        var services = new ServiceCollection();
        // Register Configuration
        services.AddSingleton<IConfigFileReader>(new FileConfigReader());
        services.AddSingleton<Configuration>();

        // Register bots
        services.AddSingleton<ISubscriber, RainBot>();
        services.AddSingleton<ISubscriber, SnowBot>();
        services.AddSingleton<ISubscriber, SunBot>();

        return services.BuildServiceProvider();
    } 
}