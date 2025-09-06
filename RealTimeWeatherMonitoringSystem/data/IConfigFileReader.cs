namespace Real_time_weather_monitoring_system.data;

public interface IConfigFileReader
{
    string ReadAllText(string path);
}