using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Articles
{
    /// <summary>
    /// 文章分类
    /// </summary>
    public class ArticleCategory : Abp.Domain.Entities.Auditing.FullAuditedEntity
    {

        /// <summary>
        /// 分类名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 分类描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int OrderNum { get; set; }

        /// <summary>
        /// 父级分类
        /// </summary>
        public virtual ArticleCategory Parent { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public virtual ICollection<ArticleCategory> Children { get; set; }
    }
}
