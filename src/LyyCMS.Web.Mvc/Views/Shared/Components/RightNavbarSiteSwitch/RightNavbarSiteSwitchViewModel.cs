using Abp.Localization;
using System.Collections.Generic;
using LyyCMS.Sites;
using LyyCMS.Sites.Dtos;

namespace LyyCMS.Web.Views.Shared.Components.RightNavbarSiteSwitch
{
    public class RightNavbarSiteSwitchViewModel
    {
        public SiteDto CurrentSite { get; set; }

        public IReadOnlyList<SiteDto> SiteList { get; set; }
    }
}
