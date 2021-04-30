using System.Collections.Generic;
using LyyCMS.Roles.Dto;

namespace LyyCMS.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}