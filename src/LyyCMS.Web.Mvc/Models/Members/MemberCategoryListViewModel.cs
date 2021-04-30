using LyyCMS.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyyCMS.Members.Dtos;

namespace LyyCMS.Web.Models.Members
{
    public class MemberCategoryListViewModel
    {

        public IReadOnlyList<CategoryListDto> CategoryList { get; set; }
    }
}
