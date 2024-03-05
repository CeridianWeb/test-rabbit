using Serilog;

public interface ILogger
{
    void Configure();
    void LogInfo(string message);
    void LogError(string message);
    void LogWarning(string message);
}
