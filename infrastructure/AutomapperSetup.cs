using AutoMapper;
using DryIoc;

public class AutomapperSetup : IAutomapperSetup
{
    public void AddRegistrations(DISetup di)
    {
        di.container.RegisterDelegate<IMapper>(
            r =>
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Test, TestDto>());
                return config.CreateMapper();
            },
            Reuse.Singleton
        );
    }
}
