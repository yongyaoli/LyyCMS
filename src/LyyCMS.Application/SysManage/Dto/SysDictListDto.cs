using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace LyyCMS.SysManage.Dto
{
    [AutoMapFrom(typeof(SysDict))]
    public class SysDictListDto: EntityDto
    {
        public string DictName { get; set; }

        public string DictCode { get; set; }

        public int DictSort { get; set; }

        /// <summary>
        /// 状态 0 禁用 1启用
        /// </summary>
        public int DictState { get; set; }


        public virtual ICollection<SysDictItemListDto> SysDictItems { get; set; }

    }
}
