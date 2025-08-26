using System.Text.Json;
using FluentAssertions;
using Real_time_weather_monitoring_system.services.parser;

namespace RealTimeWeatherMonitoringSystem.Tests.servicesTests.parserTests;

public class JsonParserShould
{

    [Fact]
    public void ParseTestCorrect()
    {
        // Arrange
        var sut = new JsonParser();
        var temperature = 32;
        var humidity = 40;
        var jsonData = $@"{{""Location"": ""City Name"", ""Temperature"": {temperature}, ""Humidity"": {humidity}}}";
        // Act
        var weather = sut.Parse(jsonData);
        
        // Assert
        weather.Temperature.Should().Be(temperature);
        weather.Humidity.Should().Be(humidity);
    }
    [Fact]
    public void ParseTestNull()
    {
        // Arrange
        var sut = new JsonParser();
        
        // Act
        Action act = () => sut.Parse(null);
        
        // Assert
        act.Should().Throw<ArgumentNullException>();
    }
    
    [Fact]
    public void ParseTestJsonError()
    {
        // Arrange
        var sut = new JsonParser();
        // Act
        Action act = () => sut.Parse("abc");
        
        // Assert
        act.Should().Throw<JsonException>();
    }
    
}