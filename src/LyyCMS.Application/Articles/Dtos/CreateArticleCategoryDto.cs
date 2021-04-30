using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Articles.Dtos
{
    public class CreateArticleCategoryDto
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

        public int ParentId { get; set; }

    }
}
