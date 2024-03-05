using CommandLine;

public class Runner : IRootObject
{
    private readonly ILogger logger;
    private readonly IGlobalSettings globalSettings;

    public Runner(ILogger logger, IGlobalSettings globalSettings)
    {
        this.logger = logger;
        this.globalSettings = globalSettings;
    }

    public void Run(string[] args)
    {
        logger.LogInfo("Started");

        //Parse the arguments
        Parser.Default
            .ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                globalSettings.Verbose = o.Verbose;
                if (o.Verbose)
                {
                    logger.LogInfo($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                }
                else
                {
                    logger.LogInfo($"Current Arguments: -v {o.Verbose}");
                }
            });
        logger.LogInfo("Finished");
    }
}
