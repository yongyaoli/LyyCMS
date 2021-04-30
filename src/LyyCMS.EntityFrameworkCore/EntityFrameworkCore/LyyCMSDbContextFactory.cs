using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LyyCMS.Configuration;
using LyyCMS.Web;

namespace LyyCMS.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LyyCMSDbContextFactory : IDesignTimeDbContextFactory<LyyCMSDbContext>
    {
        public LyyCMSDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LyyCMSDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LyyCMSDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LyyCMSConsts.ConnectionStringName));

            return new LyyCMSDbContext(builder.Options);
        }
    }
}
