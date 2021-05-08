using Abp;
using LyyCMS.Authorization.Users;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyyCMS.Articles;
using LyyCMS.Members;
using LyyCMS.Slides;
using LyyCMS.WeChat;

namespace LyyCMS.EntityFrameworkCore
{
    public static class LyyCMSDbContextModelCreatingExtensions
    {

        public static void ConfigLyyCMS(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Members.Member>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<Members.Category>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<VerificationCode>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<ArticleCategory>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<Article>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<Slide>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<SlideItem>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<WeChatAccount>().Property(x => x.Id).HasMaxLength(300);

/* Configure your own tables/entities inside here */

//builder.Entity<YourEntity>(b =>
//{
//    b.ToTable(BookConsts.DbTablePrefix + "YourEntities", BookConsts.DbSchema);

//    //...
//});
        }

        //public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
        //    where TUser : class, IUser
        //{
        //    //b.Property<string>(nameof(AppUser.MyProperty))...
        //}
    }
}
