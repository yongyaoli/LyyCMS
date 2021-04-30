using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Articles.Dtos
{
    [AutoMapFrom(typeof(ArticleCategory))]
    public class ArticleCategoryListDto: EntityDto
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
        /// 父级ID
        /// </summary>
        [NotMapped]
        public int ParentId { get; set; }

        /// <summary>
        /// 父级名称
        /// </summary>
        [NotMapped]
        public string ParentName { get; set; }

        /// <summary>
        /// 父级分类
        /// </summary>
        //public virtual ArticleCategory Parent { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        //public virtual ICollection<ArticleCategory> Children { get; set; }
    }
}
