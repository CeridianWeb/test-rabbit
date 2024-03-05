using DryIoc;

/// <summary>
/// This class is responsible for setting up the dependency injection container
/// </summary>
/// <remarks>
/// This class is responsible for setting up the dependency injection container
/// </remarks>
/// <example>
/// <code>
///    var di = new DISetup();
///    ConfigureServices(di);
///    var rootObject = di.container.Resolve<IRootObject>();
///    rootObject.Run(args);
/// </code>
/// </example>
public class DISetup : IDiSetup
{
    public Container container;

    /// <summary>
    /// This method is responsible for setting up the dependency injection container
    ///
    /// </summary>
    public DISetup()
    {
        container = new Container();
        RegisterDependencies();
    }

    /// <summary>
    /// This method is responsible for registering the dependencies
    /// </summary>
    /// <remarks>
    /// This method is responsible for registering the dependencies
    /// </remarks>
    /// <example>
    /// <code>
    ///   var di = new DISetup();
    ///     ConfigureServices(di);
    ///     var rootObject = di.container.Resolve<IRootObject>();
    ///     rootObject.Run(args);
    ///     static void ConfigureServices(DISetup di)
    ///     {
    ///     var logger = di.container.Resolve<ILogger>();
    ///     logger.Configure();
    ///     }
    ///     </code>
    ///     </example>
    public void RegisterDependencies()
    {
        // Register your dependencies here
        container.Register<IDiSetup, DISetup>();
        container.Register<IRunner, Runner>();
        container.Register<ILogger, Logger>();
        container.Register<IGlobalSettings, GlobalSettings>(Reuse.Singleton);
        container.Register<IAutomapperSetup, AutomapperSetup>();
    }
}
