using Abp.Authorization;
using LyyCMS.Authorization.Roles;
using LyyCMS.Authorization.Users;

namespace LyyCMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
