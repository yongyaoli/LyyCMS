using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LyyVueCMS.Configuration;

namespace LyyVueCMS.Web.Host.Startup
{
    [DependsOn(
       typeof(LyyVueCMSWebCoreModule))]
    public class LyyVueCMSWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LyyVueCMSWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LyyVueCMSWebHostModule).GetAssembly());
        }
    }
}
