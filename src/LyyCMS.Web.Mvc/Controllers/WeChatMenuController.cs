using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using LyyCMS.Controllers;
using LyyCMS.WeChat;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Menu;

namespace LyyCMS.Web.Controllers
{
    public class WeChatMenuController : LyyCMSControllerBase
    {
        private readonly IWeChatMenuAppService _weChatMenuAppService;
        private readonly IWeChatAccountAppService _weChatAccountAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WeChatMenuController(IWeChatAccountAppService weChatAccountAppService,
            IWeChatMenuAppService weChatMenuAppService,
            IWebHostEnvironment webHostEnvironment)
        {
            _weChatMenuAppService = weChatMenuAppService;
            _weChatAccountAppService = weChatAccountAppService;
            _webHostEnvironment = webHostEnvironment;
        }


        /// <summary>
        /// 从微信端 获取微信公众号菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        public async Task<IActionResult> GetMenuFromWx(int id=1)
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
                    GetMenuResult result = CommonApi.GetMenu(accessToken);
                    if (null != result)
                    {
                        ButtonGroupBase buttonGroupBase = result.menu;
                        buttons = buttonGroupBase.button;
                        //写入数据库
                        List<ConditionalButtonGroup> conditionalButtonGroups = result.conditionalmenu;
                        

                        Logger.Info($"微信{id}获取菜单:" + Json(result).ToString());
                    }
                    else
                    {
                        Logger.Info($"微信{id}获取菜单为空");
                    }
                    //删除菜单
                    //var result = CommonApi.DeleteMenu(accessToken);
                }
                catch (Exception e)
                {
                    Logger.Error($"微信{id}获取微信菜单失败",e);
                    return Json(buttons);
                }
            }


            return Json(buttons);
            //return View();
        }
    }
}
