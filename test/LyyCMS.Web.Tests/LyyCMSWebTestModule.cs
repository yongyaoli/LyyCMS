using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LyyCMS.EntityFrameworkCore;
using LyyCMS.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LyyCMS.Web.Tests
{
    [DependsOn(
        typeof(LyyCMSWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LyyCMSWebTestModule : AbpModule
    {
        public LyyCMSWebTestModule(LyyCMSEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LyyCMSWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LyyCMSWebMvcModule).Assembly);
        }
    }
}