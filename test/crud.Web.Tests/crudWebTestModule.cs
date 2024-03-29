using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using crud.EntityFrameworkCore;
using crud.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace crud.Web.Tests
{
    [DependsOn(
        typeof(crudWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class crudWebTestModule : AbpModule
    {
        public crudWebTestModule(crudEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(crudWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(crudWebMvcModule).Assembly);
        }
    }
}