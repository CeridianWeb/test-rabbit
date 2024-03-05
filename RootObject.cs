using CommandLine;

public class RootObject : IRootObject
{
    private readonly ILogger logger;
    private bool verbose;

    public RootObject(ILogger logger)
    {
        this.logger = logger;
    }

    public void Run(string[] args)
    {
        logger.LogInfo("Started");

        //Parse the arguments
        Parser.Default
            .ParseArguments<Options>(args)
            .WithParsed<Options>(o =>
            {
                verbose = o.Verbose;
                if (o.Verbose)
                {
                    logger.LogInfo($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                    logger.LogInfo("Quick Start Example! App is in Verbose mode!");
                }
                else
                {
                    logger.LogInfo($"Current Arguments: -v {o.Verbose}");
                    logger.LogInfo("Quick Start Example!");
                }
            });

        // Continue with the rest of your code


        logger.LogInfo("Finished");
    }
}
