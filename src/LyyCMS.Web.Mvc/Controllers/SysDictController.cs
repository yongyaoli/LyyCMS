using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Controllers;
using LyyCMS.SysManage;
using Microsoft.AspNetCore.Mvc;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SysDictController : LyyCMSControllerBase
    {

        private readonly ISysDictAppService _appService;

        public SysDictController(SysDictAppService appService)
        {
            _appService = appService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
