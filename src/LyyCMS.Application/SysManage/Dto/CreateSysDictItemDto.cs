using Abp.AutoMapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LyyCMS.SysManage.Dto
{
    [AutoMapTo(typeof(SysDictItem))]
    public class CreateSysDictItemDto
    {
        public int SysDictId { get; set; }

        public SysDict SysDict { get; set; }

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
    }
}
