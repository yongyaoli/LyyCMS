using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Controllers;
using LyyCMS.Members;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LyyCMS.WeChat;
using LyyCMS.Web.Models.Members;
using LyyCMS.Web.Models.WeChat;
using LyyCMS.WeChat.Dto;
using Abp.Application.Services.Dto;
using LyyCMS.Web.Models.Users;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.User;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Containers;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class WeChatAccountController : LyyCMSControllerBase
    {

        private readonly IWeChatAccountAppService _weChatAccountAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WeChatAccountController(IWeChatAccountAppService weChatAccountAppService,
            IWebHostEnvironment webHostEnvironment,
            ICategoryAppService categoryAppService)
        {
            _weChatAccountAppService = weChatAccountAppService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(PagedResultRequest pagedResultRequest)
        {
            var weChatAccounts = (await _weChatAccountAppService.GetAllAsync(pagedResultRequest)).Items;
            var model = new WeChatAccountViewModel
            {
                accountList = weChatAccounts
            };
            return View(model);
        }


        public async Task<ActionResult> EditModal(int userId)
        {
            var account = await _weChatAccountAppService.GetAsync(new EntityDto<int>(userId));
            var model = new EditWxAccountVIewModel()
            {
                wxAccount =  account
            };
            return PartialView("_EditModal", model);
        }

        public async Task<IActionResult> GetFans(int id = 1)
        {
            EntityDto<int> param = new EntityDto();
            param.Id = id;
            var account = await _weChatAccountAppService.GetAsync(param);
            if (null != account)
            {
                try
                {
                    var accessToken = await AccessTokenContainer.TryGetAccessTokenAsync(account.AppId, account.AppSecret);

                    OpenIdResultJson resultJson = await UserApi.GetAsync(accessToken, "");

                    Logger.Info("获取到的粉丝:"+resultJson.count);

                    var opens = resultJson.data;

                }
                catch (Exception e)
                {

                }
            }

            return null;
        }


    }
}
