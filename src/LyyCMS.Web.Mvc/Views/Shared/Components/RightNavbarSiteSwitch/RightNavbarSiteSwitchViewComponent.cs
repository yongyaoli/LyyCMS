using Abp.Application.Services.Dto;
using Abp.Configuration;
using Abp.Localization;
using LyyCMS.Sites;
using LyyCMS.Sites.Dtos;
using LyyCMS.Web.Views.Shared.Components.RightNavbarLanguageSwitch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LyyCMS.Web.Views.Shared.Components.RightNavbarSiteSwitch
{
    public class RightNavbarSiteSwitchViewComponent : LyyCMSViewComponent
    {
        private readonly ISiteAppService _siteAppService;
        private readonly ISettingManager settingManager;

        public RightNavbarSiteSwitchViewComponent(ISiteAppService siteAppService, ISettingManager settingManager)
        {
            _siteAppService = siteAppService;
            this.settingManager = settingManager;
        }

        public IViewComponentResult Invoke()
        {
            IReadOnlyList<ISettingValue> settings = settingManager.GetAllSettingValues();
            foreach (var item in settings)
            {
                string k = item.Name;
                Logger.Info("n: " + item.Name + ", v:" + item.Value);
            }
            SiteDto defaultSite = new SiteDto();
            PagedSiteResultRequestDto siteResultRequestDto = new PagedSiteResultRequestDto();
            siteResultRequestDto.SkipCount = 0;
            siteResultRequestDto.MaxResultCount = 100;

             var model = new RightNavbarSiteSwitchViewModel
            {
                CurrentSite = _siteAppService.GetAllAsync(siteResultRequestDto)?.Result.Items.FirstOrDefault(),
                SiteList = _siteAppService.GetAllAsync(siteResultRequestDto)?.Result.Items.ToList(),
            };

            return View(model);
        }
    }
}
