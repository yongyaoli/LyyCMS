using Abp.AspNetCore.Mvc.Controllers;
using LyyCMS.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace LyyCMS.Web.Controllers
{
    public class IndexController : AbpController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
