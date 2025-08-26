using AutoFixture;
using FluentAssertions;
using Real_time_weather_monitoring_system.models;
using Real_time_weather_monitoring_system.services.bots;
using RealTimeWeatherMonitoringSystem.Tests.contexts;

namespace RealTimeWeatherMonitoringSystem.Tests.servicesTests.botsTests;

[Collection("Configuration Collection")]
public class RainBotShould
{
    private Fixture _fixture;
    private ConfigurationFixture _configurationFixture;
    public RainBotShould(ConfigurationFixture configurationFixture)
    {
        _fixture = new Fixture();
        _configurationFixture = configurationFixture;
    }
    
    [Fact]
    public void UpdateTest()
    {
        // Arrange
        var weather = _fixture.Build<WeatherData>()
            .With(w => w.Humidity, 80)  
            .Create();
        var sut = new RainBot(_configurationFixture.Instance);
        var expected = "RainBot Activated\nRainBot: " + (sut.Bot?.Message ?? "");
        
        // Act
        var result = sut.Update(weather);
        
        // Assert
        result.Should().Be(expected);
    }
}