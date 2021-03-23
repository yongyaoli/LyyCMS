using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Controllers;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : LyyCMSControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
