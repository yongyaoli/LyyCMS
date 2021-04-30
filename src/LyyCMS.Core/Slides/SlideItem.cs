using Abp.Domain.Entities.Auditing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LyyCMS.Slides
{
    /// <summary>
    /// 幻灯片子项
    /// </summary>
    public class SlideItem: FullAuditedEntity
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
