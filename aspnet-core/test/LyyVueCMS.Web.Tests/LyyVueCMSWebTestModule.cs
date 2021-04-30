using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LyyVueCMS.EntityFrameworkCore;
using LyyVueCMS.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LyyVueCMS.Web.Tests
{
    [DependsOn(
        typeof(LyyVueCMSWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LyyVueCMSWebTestModule : AbpModule
    {
        public LyyVueCMSWebTestModule(LyyVueCMSEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LyyVueCMSWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LyyVueCMSWebMvcModule).Assembly);
        }
    }
}