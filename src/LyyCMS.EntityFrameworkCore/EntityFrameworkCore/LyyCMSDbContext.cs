using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LyyCMS.Authorization.Roles;
using LyyCMS.Authorization.Users;
using LyyCMS.MultiTenancy;
using LyyCMS.Members;

namespace LyyCMS.EntityFrameworkCore
{
    public class LyyCMSDbContext : AbpZeroDbContext<Tenant, Role, User, LyyCMSDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LyyCMSDbContext(DbContextOptions<LyyCMSDbContext> options)
            : base(options)
        {
        }

        //会员
        public DbSet<Member> Members { get; set; }

        public DbSet<Category> Categories { get; set; }


        //重写创建实体的方法
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Category>().ToTable("Category");


            base.OnModelCreating(modelBuilder);
        }
    }
}
