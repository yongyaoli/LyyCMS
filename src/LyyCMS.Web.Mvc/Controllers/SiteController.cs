using Abp;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.Web.Models;
using LyyCMS.Authorization;
using LyyCMS.Controllers;
using LyyCMS.Sites;
using LyyCMS.Sites.Dtos;
using LyyCMS.Web.Models.Site;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Page_Site)]
    public class SiteController : LyyCMSControllerBase
    {
        private readonly SiteAppService _siteAppService;

        public SiteController(SiteAppService siteAppService)
        {
            _siteAppService = siteAppService;
        }

        public async Task<IActionResult> Index(PagedSiteResultRequestDto input)
        {
            SiteListViewModel model = new SiteListViewModel();
            var siteList = (await _siteAppService.GetAllAsync(input)).Items;
            model.Sites = siteList;
            return View(model);
        }

        public virtual ActionResult ChangeSite(string cultureName, string returnUrl = "")
        {
            PagedSiteResultRequestDto siteResultRequestDto = new PagedSiteResultRequestDto();
            siteResultRequestDto.SkipCount = 0;
            siteResultRequestDto.MaxResultCount = 100;
            var siteList = _siteAppService.GetAllAsync(siteResultRequestDto);
            
            if (null == siteList)
            {
                throw new AbpException("Unknown site:" + cultureName + ". It mute be a valid site!");
            }

            var selectSite = siteList.Result.Items.FirstOrDefault(x => x.siteName.Equals(cultureName));
            CurrentSite = selectSite;
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureName, cultureName));

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                cookieValue,
                new CookieOptions
                {
                    Expires = Clock.Now.AddYears(2),
                    HttpOnly = true
                }
            );

            //存储
            if (AbpSession.UserId.HasValue)
            {
                string setInfo = "";
                IReadOnlyList<Abp.Configuration.ISettingValue> s = SettingManager.GetAllSettingValues();
                foreach (var settingValue in s)
                {
                    setInfo += " " + settingValue.Name + " : " + settingValue.Value;
                }

                IReadOnlyList<Abp.Configuration.ISettingValue> userSet = SettingManager.GetAllSettingValuesForUser(AbpSession.ToUserIdentifier());
                string userSetinfo = "";
                foreach (var settingValue in userSet)
                {
                    userSetinfo += " " + settingValue.Name + " : " + settingValue.Value;
                }

                //SettingManager.ChangeSettingForUser(
                //    AbpSession.ToUserIdentifier(),
                //    LyyCMSConsts.DefaultSite,
                //    cultureName
                //);
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new AjaxResponse());
            }

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                var escapedReturnUrl = Uri.EscapeDataString(returnUrl);
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
