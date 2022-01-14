using Abp;
using LyyCMS.Articles;
using LyyCMS.Members;
using LyyCMS.Regions;
using LyyCMS.Sites;
using LyyCMS.Slides;
using LyyCMS.WeChat;
using LyyCMS.WxFans;
using Microsoft.EntityFrameworkCore;

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
            //CMS
            builder.Entity<Site>().Property(x => x.Id).HasMaxLength(300);
            builder.Entity<Channel>().Property(x => x.Id).HasMaxLength(300);

            builder.Entity<Region>().Property(x => x.Id).HasMaxLength(300);
        }
    }
}
