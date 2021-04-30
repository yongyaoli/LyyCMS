using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Slides.Dtos
{
    [AutoMapFrom(typeof(SlideItem))]
    public class SlideItemListDto : EntityDto
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Required]
        public int SlideId { get; set; }

        public virtual Slide slide { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        public string title { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [Required]
        public string image { get; set; }

        /// <summary>
        /// 图片链接
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 链接打开方式
        /// </summary>
        public string target { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 状态：1 显示； 0 隐藏
        /// </summary>
        [DefaultValue(1)]
        public int status { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        [DefaultValue(99)]
        public int OrderNum { get; set; }
    }
}
