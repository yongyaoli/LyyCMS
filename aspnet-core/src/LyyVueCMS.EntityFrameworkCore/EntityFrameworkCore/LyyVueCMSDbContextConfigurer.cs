using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LyyVueCMS.EntityFrameworkCore
{
    public static class LyyVueCMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LyyVueCMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LyyVueCMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
