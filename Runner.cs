using AutoMapper;
using CommandLine;

public class Runner : IRunner
{
    private readonly ILogger logger;
    private readonly IGlobalSettings globalSettings;
    private readonly IMapper mapper;

    public Runner(ILogger logger, IGlobalSettings globalSettings, IMapper mapper)
    {
        this.logger = logger;
        this.globalSettings = globalSettings;
        this.mapper = mapper;
    }

    public void Run(string[] args)
    {
        logger.LogInfo("Started");

        //Parse the arguments
        _ = Parser.Default
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

                switch (o.Mode?.ToLower())
                {
                    case "local":
                        globalSettings.Mode = AppMode.Local;
                        break;
                    case "remote":
                        globalSettings.Mode = AppMode.Remote;
                        break;
                    default:
                        globalSettings.Mode = AppMode.None;
                        break;
                }
            });

        var test = new Test();
        test.Name = "Test Name";

        var testDto = mapper.Map<TestDto>(test);

        logger.LogInfo($"Test Dto Name = {testDto.Name}");
        logger.LogInfo($"Mode = {globalSettings.Mode}");

        logger.LogInfo("Finished");
    }
}
