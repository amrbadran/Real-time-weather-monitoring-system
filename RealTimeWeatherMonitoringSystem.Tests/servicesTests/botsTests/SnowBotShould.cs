using AutoFixture;
using FluentAssertions;
using Real_time_weather_monitoring_system.models;
using Real_time_weather_monitoring_system.services.bots;
using RealTimeWeatherMonitoringSystem.Tests.contexts;

namespace RealTimeWeatherMonitoringSystem.Tests.servicesTests.botsTests;

[Collection("Configuration Collection")]
public class SnowBotShould
{
    private Fixture _fixture;
    private ConfigurationFixture _configurationFixture;

    public SnowBotShould(ConfigurationFixture configurationFixture)
    {
        _fixture = new Fixture();
        _configurationFixture = configurationFixture;
    }

    [Fact]
    public void UpdateTest()
    {
        // Arrange
        var weather = _fixture.Build<WeatherData>()
            .With(w => w.Temperature, -3)
            .Create();
        var sut = new SnowBot(_configurationFixture.Instance);
        var expected = "SnowBot Activated\nSnowBot: " + (sut.Bot?.Message ?? "");

        // Act
        var result = sut.Update(weather);

        // Assert
        result.Should().Be(expected);
    }
}