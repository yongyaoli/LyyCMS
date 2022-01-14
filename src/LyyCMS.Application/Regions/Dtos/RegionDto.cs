using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Regions.Dtos
{

    public class RegionDto : EntityDto<int>
    {
        public int Pid;

        public string Name;

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
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
            if (string.IsNullOrEmpty(Name))
                return base.ToString();
            return Name;
        }
    }
}
