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

        Test test = new Test();
        test.Name = "Test Name";

        TestDto testDto = mapper.Map<TestDto>(test);

        logger.LogInfo($"Test Dto Name = {testDto.Name}");

        logger.LogInfo("Finished");
    }
}
