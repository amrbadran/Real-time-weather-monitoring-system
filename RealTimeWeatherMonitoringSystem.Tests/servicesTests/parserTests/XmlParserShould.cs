using FluentAssertions;
using Real_time_weather_monitoring_system.services.parser;

namespace RealTimeWeatherMonitoringSystem.Tests.servicesTests.parserTests;

public class XmlParserShould
{
    [Fact]
    public void ParseTestCorrect()
    {
        // Arrange
        var sut = new XmlParser();
        var temperature = 32;
        var humidity = 40;
        var jsonData = $"""
                       <WeatherData>
                           <Location>City Name</Location>
                           <Temperature>{temperature}</Temperature>
                           <Humidity>{humidity}</Humidity>
                       </WeatherData>
                       """;
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
        var sut = new XmlParser();

        // Act
        Action act = () => sut.Parse(null);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void ParseTestXmlError()
    {
        // Arrange
        var sut = new XmlParser();
        
        // Act
        Action act = () => sut.Parse("abc");

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }
}