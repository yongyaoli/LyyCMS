using Abp.Application.Services.Dto;
using LyyCMS.Controllers;
using LyyCMS.WeChat;
using LyyCMS.WxFans;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.Media;
using Senparc.Weixin.MP.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
    /**
     * 素材管理
     */
    public class MaterialController : LyyCMSControllerBase
    {
        private readonly IWeChatAccountAppService _weChatAccountAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MaterialController(IWeChatAccountAppService weChatAccountAppService,
            IWebHostEnvironment webHostEnvironment)
        {
            _weChatAccountAppService = weChatAccountAppService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int id=1)
        {

            EntityDto<int> param = new EntityDto();
            param.Id = id;
            var account = await _weChatAccountAppService.GetAsync(param);
            if (null != account)
            {
                try
                {
                    var accessToken = await AccessTokenContainer.TryGetAccessTokenAsync(account.AppId, account.AppSecret);
                    //获取总数
                    GetMediaCountResultJson mediaCountResult = await MediaApi.GetMediaCountAsync(accessToken);
                    //图文素材
                    MediaList_NewsResult picTxtList = await MediaApi.GetNewsMediaListAsync(accessToken, 0, 20);
                    ViewBag.picList = picTxtList;
                    //图文素材之外的其他素材
                    MediaList_OthersResult mediaList = await MediaApi.GetOthersMediaListAsync(accessToken, UploadMediaFileType.image,0, 20);
                    ViewBag.otherList = mediaList;
                }
                catch (Exception e)
                {
                    Logger.Error("获取素材出错",e);
                }
            }

            return View();
        }
    }
}
