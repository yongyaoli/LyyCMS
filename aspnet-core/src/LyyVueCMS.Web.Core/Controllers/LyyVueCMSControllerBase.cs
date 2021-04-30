using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LyyVueCMS.Controllers
{
    public abstract class LyyVueCMSControllerBase: AbpController
    {
        protected LyyVueCMSControllerBase()
        {
            LocalizationSourceName = LyyVueCMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
