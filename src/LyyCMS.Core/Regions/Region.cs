using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LyyCMS.Regions
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public class Region : FullAuditedEntity
    {
        
        public int Pid;

        [Required]
        public string RegionName;

        /// <summary>
        /// 1 正常， 0 删除
        /// </summary>
        [Required]
        [DefaultValue(1)]
        public int RegionStatus;

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        [DefaultValue(99)]
        public int OrderNum { get; set; }

        /// <summary>
        /// 父级分类
        /// </summary>
        public virtual Region Parent { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public virtual ICollection<Region> Children { get; set; }

        //selectitem
        public override string ToString()
        {
            if (string.IsNullOrEmpty(RegionName))
                return base.ToString();
            return RegionName;
        }
    }
}
