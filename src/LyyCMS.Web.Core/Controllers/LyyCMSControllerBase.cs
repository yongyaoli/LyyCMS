using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using LyyCMS.Sites.Dtos;
using Microsoft.AspNetCore.Identity;
using IUrlHelper = Abp.Web.Http.IUrlHelper;

namespace LyyCMS.Controllers
{
    public abstract class LyyCMSControllerBase: AbpController
    {
        //Õ¾µã
        protected static SiteDto CurrentSite = null;

        protected IUrlHelper UrlHelper;


        protected LyyCMSControllerBase(IUrlHelper urlHelper)
        {
            UrlHelper = urlHelper;
        }


        protected LyyCMSControllerBase()
        {
            LocalizationSourceName = LyyCMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
         
    }
}
