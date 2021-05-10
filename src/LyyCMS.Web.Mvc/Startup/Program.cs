using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LyyCMS.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("host.json")
                .Build();
            var url = configuration["url"];

            return WebHost.CreateDefaultBuilder(args)
                .UseUrls(configuration["url"])
                .UseStartup<Startup>()
                .Build();
        }
    }
}
