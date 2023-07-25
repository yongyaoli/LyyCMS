using Abp.Configuration;
using LyyCMS.Sites;
using LyyCMS.Sites.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
            SiteDto defaultSite = new SiteDto();
            PagedSiteResultRequestDto siteResultRequestDto = new PagedSiteResultRequestDto();
            siteResultRequestDto.SkipCount = 0;
            siteResultRequestDto.MaxResultCount = 100;
            IReadOnlyList<ISettingValue> settings = settingManager.GetAllSettingValues();
            defaultSite = _siteAppService.GetAllAsync(siteResultRequestDto)?.Result.Items.FirstOrDefault();
            foreach (var item in settings)
            {
                string k = item.Name;
                Logger.Info("n: " + item.Name + ", v:" + item.Value);
                if(item.Name == LyyCMSConsts.DefaultSite)
                {
                    defaultSite = _siteAppService.GetAllAsync(siteResultRequestDto)?.Result.Items.Where(x => x.Id == int.Parse(item.Value)).FirstOrDefault();
                }
            }
            

            var model = new RightNavbarSiteSwitchViewModel
            {
                CurrentSite = defaultSite,
                SiteList = _siteAppService.GetAllAsync(siteResultRequestDto)?.Result.Items.ToList(),
            };

            return View(model);
        }
    }
}
