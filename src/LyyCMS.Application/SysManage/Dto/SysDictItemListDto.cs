using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LyyCMS.SysManage.Dto
{
    [AutoMapFrom(typeof(SysDictItem))]
    public class SysDictItemListDto : EntityDto
    {
        public int SysDictId { get; set; }

        

        [Required]
        [DisplayName("名称")]
        public string ItemName { get; set; }

        [Required]
        [DisplayName("编码")]
        public string ItemCode { get; set; }

        [Required]
        [DisplayName("值")]
        public string ItemVal { get; set; }

        [DisplayName("排序")]
        [DefaultValue(1)]
        public int ItemSort { get; set; }

        /// <summary>
        /// 状态  0禁用  1启用
        /// </summary>
        [DisplayName("状态")]
        [DefaultValue(1)]
        public int ItemState { get; set; }

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

    }
}
