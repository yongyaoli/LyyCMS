using System.Collections.Generic;
using LyyCMS.Roles.Dto;

namespace LyyCMS.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
