using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Controllers;
using Castle.Core.Logging;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LyyCMSControllerBase
    {

        //AbpController 已有
        //public ILogger Logger { get; set; }

        //public HomeController()
        //{
        //    Logger = NullLogger.Instance;
        //}

        public ActionResult Index()
        {

            Logger.Info("start home 888 ... ");

            return View();
        }
    }
}
