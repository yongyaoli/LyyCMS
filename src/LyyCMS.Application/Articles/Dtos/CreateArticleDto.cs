using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Articles.Dtos
{
    [AutoMapTo(typeof(Article))]
    public class CreateArticleDto
    {

        public string title { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int articleCategoryId { get; set; }

        /// <summary>
        /// 所属分类
        /// </summary>
        public ArticleCategory category { get; set; }


        /// <summary>
        /// 内容(富文本编辑器)
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool top { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool red { get; set; }

        /// <summary>
        /// 是否可以评论
        /// </summary>
        public bool comment { get; set; }

        /// <summary>
        /// 评论数量
        /// </summary>
        public int comment_count { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        public int hit { get; set; }

        /// <summary>
        /// 收藏数量
        /// </summary>
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
        public int status { get; set; }
    }
}
