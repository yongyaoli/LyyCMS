using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LyyVueCMS.Authorization.Roles;
using LyyVueCMS.Authorization.Users;
using LyyVueCMS.MultiTenancy;

namespace LyyVueCMS.EntityFrameworkCore
{
    public class LyyVueCMSDbContext : AbpZeroDbContext<Tenant, Role, User, LyyVueCMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LyyVueCMSDbContext(DbContextOptions<LyyVueCMSDbContext> options)
            : base(options)
        {
        }
    }
}
