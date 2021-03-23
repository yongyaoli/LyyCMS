using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LyyCMS.EntityFrameworkCore
{
    public static class LyyCMSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LyyCMSDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LyyCMSDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
