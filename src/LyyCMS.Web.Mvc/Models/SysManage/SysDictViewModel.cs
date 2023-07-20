using LyyCMS.Sites.Dtos;
using LyyCMS.SysManage;
using LyyCMS.SysManage.Dto;
using System.Collections.Generic;

namespace LyyCMS.Web.Models.SysMangae
{
    public class SysDictViewModel
    {
        public IReadOnlyList<SysDict> SysDicts { get; set; }

        //public IReadOnlyList<SysDictItemListDto> TreeData { get; set; }

    }
}
