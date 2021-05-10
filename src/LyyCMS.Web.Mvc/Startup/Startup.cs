using Abp.AspNetCore;
using Abp.AspNetCore.Mvc.Antiforgery;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Castle.Logging.Log4Net;
using Abp.Dependency;
using Abp.Json;
using Castle.Facilities.Logging;
using LyyCMS.Authentication.JwtBearer;
using LyyCMS.Configuration;
using LyyCMS.Identity;
using LyyCMS.Web.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Senparc.CO2NET.RegisterServices;
using System;
using System.IO;
using System.Linq;
using Senparc.Weixin.RegisterServices;
using UEditor.Core;
using Senparc.CO2NET;
using Senparc.Weixin.Entities;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Microsoft.Extensions.Options;
using Senparc.CO2NET.Cache;
using System.Collections.Generic;
using Register = Senparc.CO2NET.Register;

namespace LyyCMS.Web.Startup
{
    public class Startup
    {
        private readonly IConfigurationRoot _appConfiguration;

        public Startup(IWebHostEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //ueditor
            services.AddUEditorService();
            // MVC
            services.AddControllersWithViews(
                    options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                        options.Filters.Add(new AbpAutoValidateAntiforgeryTokenAttribute());
                    }
                )
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new AbpMvcContractResolver(IocManager.Instance)
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                });

            IdentityRegistrar.Register(services);
            AuthConfigurer.Configure(services, _appConfiguration);

            services.AddScoped<IWebResourceManager, WebResourceManager>();

            services.AddSignalR();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "LyyCMS API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
            });


            services.AddSenparcGlobalServices(_appConfiguration)//Senparc.CO2NET 全局注册
                .AddSenparcWeixinServices(_appConfiguration);//Senparc.Weixin 注册


            // Configure Abp and Dependency Injection
            return services.AddAbp<LyyCMSWebMvcModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, 
            IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {

            app.UseAbp(); // Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            //静态资源
            string temp = Path.Combine(env.WebRootPath, "upload");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "upload")),
                RequestPath = "/upload",
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=36000");
                }
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseJwtTokenMiddleware();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<AbpCommonHub>("/signalr");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            //Enable middleware to serve swagger - ui assets(HTML, JS, CSS etc.)
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "LyyCMS API V1");
            }); //URL: /swagger 


        // 启动 CO2NET 全局注册，必须！
        IRegisterService register = RegisterService.Start(senparcSetting.Value)
                .UseSenparcGlobal(false, () => GetExCacheStrategies(senparcSetting.Value));

            register.UseSenparcWeixin(senparcWeixinSetting.Value, senparcSetting.Value)

                #region 注册公众号或小程序（按需）

                //注册公众号
                .RegisterMpAccount(
                    senparcWeixinSetting.Value.WeixinAppId,
                    senparcWeixinSetting.Value.WeixinAppSecret,
                    "【盛派网络小助手】公众号");

            #endregion

        }


        /// <summary>
        /// 获取扩展缓存策略
        /// </summary>
        /// <returns></returns>
        private IList<IDomainExtensionCacheStrategy> GetExCacheStrategies(SenparcSetting senparcSetting)
        {
            var exContainerCacheStrategies = new List<IDomainExtensionCacheStrategy>();
            senparcSetting = senparcSetting ?? new SenparcSetting();

            //注意：以下两个 if 判断仅作为演示，方便大家添加自定义的扩展缓存策略，
            //      只要进行了 register.UseSenparcWeixin() 操作，Container 的缓存策略下的 Local、Redis 和 Memcached 系统已经默认自动注册，无需操作！

            #region 演示扩展缓存注册方法

            //判断Redis是否可用
            var redisConfiguration = senparcSetting.Cache_Redis_Configuration;
            if ((!string.IsNullOrEmpty(redisConfiguration) && redisConfiguration != "Redis配置"))
            {
                //exContainerCacheStrategies.Add(RedisContainerCacheStrategy.Instance);
            }

            //判断Memcached是否可用
            var memcachedConfiguration = senparcSetting.Cache_Memcached_Configuration;
            if ((!string.IsNullOrEmpty(memcachedConfiguration) && memcachedConfiguration != "Memcached配置"))
            {
                //exContainerCacheStrategies.Add(MemcachedContainerCacheStrategy.Instance);//TODO:如果没有进行配置会产生异常
            }

            #endregion

            //扩展自定义的缓存策略

            return exContainerCacheStrategies;
        }

    }
}
