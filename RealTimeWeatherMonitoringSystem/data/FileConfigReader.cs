namespace Real_time_weather_monitoring_system.data;

public class FileConfigReader : IConfigFileReader
{
    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }
}