using LyyCMS.Articles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LyyCMS.Regions
{
    /// <summary>
    /// 区域管理
    /// </summary>
    public class Region : Abp.Domain.Entities.Auditing.FullAuditedEntity
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
