using FluentAssertions;
using Real_time_weather_monitoring_system.services.parser;

namespace RealTimeWeatherMonitoringSystem.Tests.servicesTests.parserTests;

public class ParserFactoryShould
{
    [Fact]
    public void BuildJsonParserTest()
    {
        // Arrange
        var jsonData = @"{""Location"": ""City Name"", ""Temperature"": 32, ""Humidity"": 40}";
        
        // Act
        var parser = ParserFactory.Create(jsonData);
        
        // Assert
        parser.Should().BeOfType<JsonParser>();
    }
    
    [Fact]
    public void BuildXmlParserTest()
    {
        // Arrange
        var jsonData = @"<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>";
        
        // Act
        var parser = ParserFactory.Create(jsonData);
        
        // Assert
        parser.Should().BeOfType<XmlParser>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("")]
    public void TestForNullAndWhiteSpaces(string? data)
    {
        // Arrange & Act
        Action act  = () =>  ParserFactory.Create(data);
        
        // Assert
        act.Should().Throw<InvalidOperationException>();
    }
}