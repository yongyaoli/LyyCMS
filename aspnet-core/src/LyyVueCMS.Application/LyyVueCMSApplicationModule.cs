using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LyyVueCMS.Authorization;

namespace LyyVueCMS
{
    [DependsOn(
        typeof(LyyVueCMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LyyVueCMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LyyVueCMSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LyyVueCMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
