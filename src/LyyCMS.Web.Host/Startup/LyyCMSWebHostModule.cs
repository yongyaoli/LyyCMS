using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LyyCMS.Configuration;

namespace LyyCMS.Web.Host.Startup
{
    [DependsOn(
       typeof(LyyCMSWebCoreModule))]
    public class LyyCMSWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LyyCMSWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LyyCMSWebHostModule).GetAssembly());
        }
    }
}
