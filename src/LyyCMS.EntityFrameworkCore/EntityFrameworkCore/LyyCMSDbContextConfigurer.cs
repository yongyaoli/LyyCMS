using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LyyCMS.EntityFrameworkCore
{
    public static class LyyCMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LyyCMSDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            

            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public static void Configure(DbContextOptionsBuilder<LyyCMSDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection, ServerVersion.AutoDetect(connection.ConnectionString));
        }
    }
}
