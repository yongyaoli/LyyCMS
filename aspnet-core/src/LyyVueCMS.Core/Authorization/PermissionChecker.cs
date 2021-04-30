using Abp.Authorization;
using LyyVueCMS.Authorization.Roles;
using LyyVueCMS.Authorization.Users;

namespace LyyVueCMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
