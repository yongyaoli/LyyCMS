using Abp.Domain.Entities.Auditing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LyyCMS.Articles
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article: FullAuditedEntity
    {


        [Required]
        public string title { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        [Required]
        public int articleCategoryId { get; set; }

        /// <summary>
        /// 所属分类
        /// </summary>
        public ArticleCategory category { get; set; }


        /// <summary>
        /// 内容(富文本编辑器)
        /// </summary>
        [Required]
        public string content { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        [DefaultValue(false)]
        public bool top { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        [DefaultValue(false)]
        public bool red { get; set; }

        /// <summary>
        /// 是否可以评论
        /// </summary>
        [DefaultValue(false)]
        public bool comment { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        [DefaultValue(0)]
        public int comment_count { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        [DefaultValue(0)]
        public int hit { get; set; }

        /// <summary>
        /// 收藏数量
        /// </summary>
        [DefaultValue(0)]
        public int favorite { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string source { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string thumbnail { get; set; }


        /// <summary>
        /// 状态: 默认0(新建) ，1(发布/生效), 2 
        /// </summary>
        [DefaultValue(0)]
        public int status { get; set; }
    }
}
