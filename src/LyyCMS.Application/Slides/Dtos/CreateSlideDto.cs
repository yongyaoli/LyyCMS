using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Slides.Dtos
{
    [AutoMapTo(typeof(Slide))]
    public class CreateSlideDto
    {
        /// <summary>
        /// 名称
        /// </summary>
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
