using LyyCMS.Controllers;
using LyyCMS.Members;
using LyyCMS.WeChat;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using LyyCMS.WeChat.Dto;
using Google.Protobuf.WellKnownTypes;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Entities.Menu;

namespace LyyCMS.Web.Controllers
{
    public class WeChatMenuController : LyyCMSControllerBase
    {
        private readonly IWeChatAccountAppService _weChatAccountAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WeChatMenuController(IWeChatAccountAppService weChatAccountAppService,
            IWebHostEnvironment webHostEnvironment)
        {
            _weChatAccountAppService = weChatAccountAppService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> GetMenu(int id=1)
        {
            List<BaseButton> buttons = new List<BaseButton>();
            EntityDto<int> param = new EntityDto();
            param.Id = id;
            var account = await _weChatAccountAppService.GetAsync(param);
            if (null != account)
            {
                try
                {
                    var accessToken = AccessTokenContainer.TryGetAccessToken(account.AppId, account.AppSecret);
                    //菜单查询
                    var result = CommonApi.GetMenu(accessToken);
                    if (null != result)
                    {
                        ButtonGroupBase buttonGroupBase = result.menu;
                        buttons = buttonGroupBase.button;
                    }
                    //删除菜单
                    //var result = CommonApi.DeleteMenu(accessToken);
                }
                catch (Exception e)
                {
                    return Json(buttons);
                }
            }


            return Json(buttons);
            //return View();
        }
    }
}
