using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LyyVueCMS.Configuration;
using LyyVueCMS.Web;

namespace LyyVueCMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LyyVueCMSDbContextFactory : IDesignTimeDbContextFactory<LyyVueCMSDbContext>
    {
        public LyyVueCMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LyyVueCMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LyyVueCMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LyyVueCMSConsts.ConnectionStringName));

            return new LyyVueCMSDbContext(builder.Options);
        }
    }
}
