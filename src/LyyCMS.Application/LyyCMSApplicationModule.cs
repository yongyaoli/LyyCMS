using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LyyCMS.Authorization;

namespace LyyCMS
{
    [DependsOn(
        typeof(LyyCMSCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LyyCMSApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LyyCMSAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LyyCMSApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
