using LyyCMS.Controllers;
using LyyCMS.Sites;
using LyyCMS.Sites.Dtos;
using LyyCMS.Web.Models.Roles;
using LyyCMS.Web.Models.Site;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
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


    }
}
