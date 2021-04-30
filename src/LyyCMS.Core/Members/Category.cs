using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Members
{
    /// <summary>
    /// 会员分类
    /// </summary>
    public class Category: Abp.Domain.Entities.Auditing.FullAuditedEntity
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 分类描述
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Desc { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
    }
}
