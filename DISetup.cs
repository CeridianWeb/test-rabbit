using DryIoc;

public class DISetup
{
    public Container container;

    public DISetup()
    {
        container = new Container();
        RegisterDependencies();
    }

    public void RegisterDependencies()
    {
        // Register your dependencies here
        container.Register<IRootObject, RootObject>();
        container.Register<ILogger, Logger>();
    }
}
