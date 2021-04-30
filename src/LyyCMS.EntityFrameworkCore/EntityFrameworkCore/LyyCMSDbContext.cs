using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LyyCMS.Authorization.Roles;
using LyyCMS.Authorization.Users;
using LyyCMS.MultiTenancy;
using LyyCMS.Members;
using LyyCMS.EntityMapper.VerificationCodes;
using LyyCMS.Articles;
using LyyCMS.Slides;

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

        //验证码
        public DbSet<VerificationCode> VerificationCodes { get; set; }

        public DbSet<ArticleCategory> ArticleCategory { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<Slide> Slide { get; set; }

        public DbSet<SlideItem> SlideItems { get; set; }


        //重写创建实体的方法
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<VerificationCode>().ToTable("VerificationCode");
            modelBuilder.Entity<ArticleCategory>().ToTable("ArticleCategory")
                .Property(x=>x.OrderNum)
                .HasDefaultValue(99);

            modelBuilder.Entity<Article>().ToTable("Article")
                .Property(x => x.status)
                .HasDefaultValue(0);

            modelBuilder.Entity<Slide>().ToTable("Slide");

            modelBuilder.Entity<SlideItem>().ToTable("SlideItems");

            base.OnModelCreating(modelBuilder);
        }
    }
}
