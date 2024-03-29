using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using crud.Authorization;

namespace crud
{
    [DependsOn(
        typeof(crudCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class crudApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<crudAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(crudApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
