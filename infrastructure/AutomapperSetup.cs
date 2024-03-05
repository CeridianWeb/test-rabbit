using AutoMapper;
using DryIoc;

public class AutomapperSetup : IAutomapperSetup
{
    public void AddRegistrations(DISetup di)
    {
        di.container.RegisterDelegate<IMapper>(
            r =>
            {
                var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
                return config.CreateMapper();
            },
            Reuse.Singleton
        );
    }
}
