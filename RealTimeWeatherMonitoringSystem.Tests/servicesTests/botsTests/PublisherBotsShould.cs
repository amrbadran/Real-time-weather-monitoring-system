using Real_time_weather_monitoring_system.services.bots;
using Moq;
using FluentAssertions;
using AutoFixture;
using Real_time_weather_monitoring_system.models;

namespace RealTimeWeatherMonitoringSystem.Tests.servicesTests.botsTests;

public class PublisherBotsShould
{
    private Fixture _fixture;
    private Mock<ISubscriber> _mockSubscriber;
    private List<String> _messagesReturned;
    private WeatherData _weatherData;

    private const int CountOfSubscribers = 3;

    public PublisherBotsShould()
    {
        _fixture = new Fixture();
        _mockSubscriber = new Mock<ISubscriber>();
        _messagesReturned = _fixture.CreateMany<string>(CountOfSubscribers).ToList();
        _weatherData = _fixture.Create<WeatherData>();

        _mockSubscriber.SetupSequence(m => m.Update(It.IsAny<WeatherData>()))
            .Returns(_messagesReturned[0])
            .Returns(_messagesReturned[1])
            .Returns(_messagesReturned[2]);
    }

    [Fact]
    public void NotifyAllTest()
    {
        // Arrange
        var sut = new PublisherBots(_weatherData);
        // Register Subscribers
        for (int i = 0; i < CountOfSubscribers; ++i) 
            sut.Subscribe(_mockSubscriber.Object);
        
        // Act
        var messages = sut.NotifyAll();

        // Assert
        messages.Should().BeEquivalentTo(_messagesReturned);
    }
}