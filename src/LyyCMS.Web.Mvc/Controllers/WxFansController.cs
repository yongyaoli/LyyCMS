using LyyCMS.Controllers;
using LyyCMS.WeChat;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using LyyCMS.WxFans;

namespace LyyCMS.Web.Controllers
{
    public class WxFansController : LyyCMSControllerBase
    {
        
        private readonly IWeChatAccountAppService _weChatAccountAppService;
        private readonly IWxFansInfoAppService _wxFansInfoAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public WxFansController(IWeChatAccountAppService weChatAccountAppService,
            IWxFansInfoAppService wxFansInfoAppService,
            IWebHostEnvironment webHostEnvironment)
        {
            _weChatAccountAppService = weChatAccountAppService;
            _wxFansInfoAppService = wxFansInfoAppService;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task<IActionResult> Index(int id)
        {
            var aid = id;
            EntityDto<int> dto = new EntityDto();
            dto.Id = aid;
            var account = await _weChatAccountAppService.GetAsync(dto);
            ViewData["account"] = account;
            return View();
        }
    }
}
