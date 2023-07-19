﻿using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LyyCMS.SysManage
{
    /// <summary>
    /// 数据字典
    /// </summary>
    public class SysDict : FullAuditedEntity
    {

        public SysDict() { }

        [Required]
        [DisplayName("字典名称")]
        public string DictName { get; set; }

        [Required]
        [DisplayName("字典编号")]
        public string DictCode { get; set; }

        [DisplayName("排序")]
        [DefaultValue(1)]
        public int DictSort { get; set; }

        /// <summary>
        /// 状态 0 禁用 1启用
        /// </summary>
        [DisplayName("状态")]
        [DefaultValue(1)]
        public int DictState { get; set; }


        public virtual ICollection<SysDictItem> SysDictItems { get; set; }
    }
}
