using Abp;
using LyyCMS.Articles;
using LyyCMS.Members;
using LyyCMS.Slides;
using LyyCMS.WeChat;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyyCMS.WxFans;

namespace LyyCMS.EntityFrameworkCore
{
    public static class IdentityServerModelCreatingExtensions
    {
        /// <summary>
        /// 修复mysql 字段过长报错
        /// https://github.com/abpframework/abp/issues/1920
        /// </summary>
        /// <param name="builder"></param>
        public static void ConfigureIdentityServerForMySQL(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));


            builder.Entity<Members.Member>().Property(x=>x.Id).HasMaxLength(300);

            builder.Entity<Members.Category>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<VerificationCode>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<ArticleCategory>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<Article>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<Slide>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<SlideItem>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<WeChatAccount>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<WxFansGroup>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<WxFansInfo>().Property(x => x.Id).HasMaxLength(300);

        }
    }
}
