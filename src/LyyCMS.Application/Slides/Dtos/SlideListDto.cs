using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace LyyCMS.Slides.Dtos
{
    [AutoMapFrom(typeof(Slide))]
    public class SlideListDto : EntityDto
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
