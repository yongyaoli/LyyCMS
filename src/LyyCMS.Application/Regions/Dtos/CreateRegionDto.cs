using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Regions.Dtos
{

    public class CreateRegionDto
    {
        public int Pid;

        public string RegionName;

        /// <summary>
        /// 1 正常， 0 删除
        /// </summary>
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
