using AutoMapper;
using DryIoc;

public class AutomapperSetup : IAutomapperSetup
{
    public void AddRegistrations(IDiSetup di)
    {
        di.Container.RegisterDelegate<IMapper>(
            r =>
            {
                var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
                return config.CreateMapper();
            },
            Reuse.Singleton
        );
    }
}
