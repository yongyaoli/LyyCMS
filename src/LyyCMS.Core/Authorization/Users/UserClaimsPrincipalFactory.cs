using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using LyyCMS.Authorization.Roles;
using Abp.Domain.Uow;

namespace LyyCMS.Authorization.Users
{
    public class UserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            IUnitOfWorkManager unitOfWorkManger)
            : base(
                  userManager,
                  roleManager,
                  optionsAccessor,
                  unitOfWorkManger)
        {
        }
    }
}
