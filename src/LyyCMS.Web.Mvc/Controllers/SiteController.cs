using Abp;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.Web.Models;
using LyyCMS.Authorization;
using LyyCMS.Controllers;
using LyyCMS.Sites;
using LyyCMS.Sites.Dtos;
using LyyCMS.Slides.Dtos;
using LyyCMS.Web.Models.Site;
using LyyCMS.Web.Models.Slide;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SiteController : LyyCMSControllerBase
    {
        private readonly SiteAppService _siteAppService;
        private readonly ChannAppService _channAppService;
        private readonly Abp.Web.Http.IUrlHelper _urlHelper;

        public SiteController(SiteAppService siteAppService, ChannAppService channAppService, Abp.Web.Http.IUrlHelper urlHelper)
        {
            _siteAppService = siteAppService;
            _channAppService = channAppService;
            _urlHelper = urlHelper;
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
            //var reqCul = new RequestCulture(cultureName);
            //var cookieValue = CookieRequestCultureProvider.MakeCookieValue(reqCul);

            Response.Cookies.Append(
                LyyCMSConsts.DefaultSite,
                CurrentSite.Id.ToString(),
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
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new AjaxResponse());
            }

            if (!string.IsNullOrWhiteSpace(returnUrl))
            {
                var escapedReturnUrl = Uri.EscapeDataString(returnUrl);
                if(null != _urlHelper)
                {
                    var localPath = _urlHelper.LocalPathAndQuery(escapedReturnUrl, Request.Host.Host, Request.Host.Port);
                    if (!string.IsNullOrWhiteSpace(localPath))
                    {
                        var unescapedLocalPath = Uri.UnescapeDataString(localPath);
                        if (Url.IsLocalUrl(unescapedLocalPath))
                        {
                            return LocalRedirect(unescapedLocalPath);
                        }
                    }
                }
                
            }

            return LocalRedirect("/"); //TODO: Go to app root
        }


        public async Task<ActionResult> EditModal(int Id)
        {
            SiteDto site = new SiteDto();
            site.Id = Id;
            var output = await _siteAppService.GetAsync(site);
            //var channelList = await _channAppService.g
            EditSiteModalViewModel model = new EditSiteModalViewModel()
            {
                Site = output
            };

            return PartialView("_EditModal", model);
        }

        public async Task<IActionResult> ChannelList()
        {

            return null;
        }
    }
}
