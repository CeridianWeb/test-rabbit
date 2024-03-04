using DryIoc;

var container = new Container();

// Register your dependencies here
container.Register<IService, Service>();

// Resolve the root object test the dependencies
var rootObject = container.Resolve<IRootObject>();

// Use the root object
rootObject.DoSomething(); 

public interface IService
{
    void DoSomething();
}

public class Service : IService
{
    public void DoSomething()
    {
        Console.WriteLine("Doing something...");
    }
}

public interface IRootObject
{
    void DoSomething();
}

public class RootObject : IRootObject
{
    private readonly IService _service;

    public RootObject(IService service)
    {
        _service = service;
    }

    public void DoSomething()
    {
        _service.DoSomething();
    }
}
