using LyyCMS.Members.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Models.Members
{
    public class MemberListViewModel
    {

        public IReadOnlyList<CategoryListDto> Categories { get; set; }
    }
}
