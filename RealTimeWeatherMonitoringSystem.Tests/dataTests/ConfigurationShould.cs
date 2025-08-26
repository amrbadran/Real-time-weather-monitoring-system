using Real_time_weather_monitoring_system.data;
using Moq;
using FluentAssertions;


namespace RealTimeWeatherMonitoringSystem.Tests.dataTests;

public class ConfigurationShould
{
    private Mock<IConfigFileReader> _mockConfigFileReader;
    private string _configJson;

    public ConfigurationShould()
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
    }

    [Fact]
    public void LoadTest()
    {
        // Arrange & Act
        var sut = new Configuration(_mockConfigFileReader.Object);
        
        // Assert

        sut.Bots.Should().ContainKeys("RainBot", "SunBot", "SnowBot");
        sut.Bots["RainBot"].HumidityThreshold.Should().Be(70);
    }
}