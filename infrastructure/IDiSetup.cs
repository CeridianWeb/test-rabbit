using DryIoc;

public interface IDiSetup
{
    
    IContainer Container { get; set; }
    void RegisterDependencies();
}
