using System.Collections.Generic;
using LyyCMS.Roles.Dto;

namespace LyyCMS.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
