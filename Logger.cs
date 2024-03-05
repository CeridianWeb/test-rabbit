using Serilog;

public class Logger : ILogger
{
    public void Configure()
    {
        // Configure Serilog
        Log.Logger = new LoggerConfiguration().WriteTo
            .Console()
            .WriteTo.File("log.txt")
            .CreateLogger();
    }

    public void LogInfo(string message)
    {
        Log.Information(message);
    }

    public void LogError(string message)
    {
        Log.Error(message);
    }

    public void LogWarning(string message)
    {
        Log.Warning(message);
    }
}
