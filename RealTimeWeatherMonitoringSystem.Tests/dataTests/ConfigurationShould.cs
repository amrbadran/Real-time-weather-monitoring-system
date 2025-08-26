using Real_time_weather_monitoring_system.data;
using Moq;
using FluentAssertions;
using RealTimeWeatherMonitoringSystem.Tests.contexts;


namespace RealTimeWeatherMonitoringSystem.Tests.dataTests;

[Collection("Configuration Collection")]
public class ConfigurationShould
{
    private ConfigurationFixture _configurationFixture;

    public ConfigurationShould(ConfigurationFixture configurationFixture)
    {
        _configurationFixture = configurationFixture;
    }

    [Fact]
    public void LoadTest()
    {
        // Arrange & Act
        var sut = _configurationFixture;
        
        // Assert

        sut.Instance.Bots.Should().ContainKeys("RainBot", "SunBot", "SnowBot");
        sut.Instance.Bots["RainBot"].HumidityThreshold.Should().Be(70);
    }
}