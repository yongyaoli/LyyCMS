using Abp;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.AspNetCore.Mvc.Extensions;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.Web.Models;
using LyyCMS.Sites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using IUrlHelper = Abp.Web.Http.IUrlHelper;

namespace LyyCMS.Controllers
{
    public abstract class LyyCMSControllerBase: AbpController
    {
        //Õ¾µã

        protected IUrlHelper UrlHelper;

        protected ISiteAppService siteAppService;

        protected LyyCMSControllerBase(IUrlHelper urlHelper,ISiteAppService _siteAppService)
        {
            UrlHelper = urlHelper;
            siteAppService = _siteAppService;
        }


        protected LyyCMSControllerBase()
        {
            LocalizationSourceName = LyyCMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public virtual ActionResult ChangeSite(string siteName, string returnUrl = "")
        {
            var siteList = siteAppService.GetAllAsync(null);
            var selectSite = siteList.Result.Items.FirstOrDefault(x => x.siteName.Equals(siteName));
            if (null==siteList)
            {
                throw new AbpException("Unknown site:"+siteName+". It mute be a valid site!");
            }


            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(siteName, siteName));

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                cookieValue,
                new CookieOptions
                {
                    Expires = Clock.Now.AddYears(2),
                    HttpOnly = true
                }
            );

            //´æ´¢
            if (AbpSession.UserId.HasValue)
            {
                SettingManager.ChangeSettingForUser(
                    AbpSession.ToUserIdentifier(),
                    LyyCMSConsts.DefaultSite,
                    siteName
                );
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new AjaxResponse());
            }

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                var escapedReturnUrl = Uri.EscapeUriString(returnUrl);
                var localPath = UrlHelper.LocalPathAndQuery(escapedReturnUrl, Request.Host.Host, Request.Host.Port);
                if (!string.IsNullOrWhiteSpace(localPath))
                {
                    var unescapedLocalPath = Uri.UnescapeDataString(localPath);
                    if (Url.IsLocalUrl(unescapedLocalPath))
                    {
                        return LocalRedirect(unescapedLocalPath);
                    }
                }
            }

            return LocalRedirect("/"); //TODO: Go to app root
        }
    }
}
