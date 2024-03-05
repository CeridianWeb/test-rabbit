using DryIoc;

//Register the dependencies
var di = new DISetup();
ConfigureServices(di);

// Resolve the root object test the dependencies
var rootObject = di.Container.Resolve<IRunner>();

// Use the root object
rootObject.Run(args);

static void ConfigureServices(DISetup di)
{
    var logger = di.Container.Resolve<ILogger>();
    logger.Configure();

    //Automapper setup
    var automapperSetup = di.Container.Resolve<IAutomapperSetup>();
    automapperSetup.AddRegistrations(di);
}
