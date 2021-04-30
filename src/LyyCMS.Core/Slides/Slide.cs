using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Slides
{
    /// <summary>
    /// 幻灯片
    /// </summary>
    public class Slide: FullAuditedEntity
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 幻灯片子项
        /// </summary>
        public virtual ICollection<SlideItem> SlideItems { get; set; }

    }
}
