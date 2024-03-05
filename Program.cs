using DryIoc;

//Register the dependencies
var di = new DISetup();
ConfigureServices(di);

// Resolve the root object test the dependencies
var rootObject = di.container.Resolve<IRunner>();

// Use the root object
rootObject.Run(args);

static void ConfigureServices(DISetup di)
{
    var logger = di.container.Resolve<ILogger>();
    logger.Configure();

    //Automapper setup
    var automapperSetup = di.container.Resolve<IAutomapperSetup>();
    automapperSetup.AddRegistrations(di);
}
