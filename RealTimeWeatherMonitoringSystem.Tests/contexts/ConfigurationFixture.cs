using Real_time_weather_monitoring_system.data;

namespace RealTimeWeatherMonitoringSystem.Tests.contexts;

using Moq;

public class ConfigurationFixture : IDisposable
{
    private Mock<IConfigFileReader> _mockConfigFileReader;
    private string _configJson;
    private Configuration _configuration;

    public ConfigurationFixture()
    {
        _configJson = """
                      {
                        "RainBot": {
                          "enabled": true,
                          "humidityThreshold": 70,
                          "message": "It looks like it's about to pour down!"
                        },
                        "SunBot": {
                          "enabled": true,
                          "temperatureThreshold": 30,
                          "message": "Wow, it's a scorcher out there!"
                        },
                        "SnowBot": {
                          "enabled": false,
                          "temperatureThreshold": 0,
                          "message": "Brrr, it's getting chilly!"
                        }
                      }
                      """;
        _mockConfigFileReader = new Mock<IConfigFileReader>();
        _mockConfigFileReader.Setup(m => m.ReadAllText(It.IsAny<string>()))
            .Returns(_configJson);
        _configuration = new Configuration(_mockConfigFileReader.Object);
    }

    public Configuration Instance
    {
        get => _configuration;
    }

    public void Dispose()
    {
        // Empty Implementation   
    }
}