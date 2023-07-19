using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Authorization;
using LyyCMS.Controllers;
using LyyCMS.Sites;
using Microsoft.AspNetCore.Mvc;

namespace LyyCMS.Web.Controllers
{
    /// <summary>
    /// 站点频道
    /// </summary>
    [AbpMvcAuthorize]
    public class ChannelController : LyyCMSControllerBase
    {
        private readonly ChannAppService _channelAppService;

        public ChannelController(ChannAppService channAppService) {
            _channelAppService = channAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
