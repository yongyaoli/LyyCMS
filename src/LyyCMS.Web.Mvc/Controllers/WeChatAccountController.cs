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
using LyyCMS.WxFans;
using LyyCMS.WxFans.Dto;
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
        private readonly IWxFansInfoAppService _wxFansInfoAppService;

        public WeChatAccountController(IWeChatAccountAppService weChatAccountAppService,
            IWebHostEnvironment webHostEnvironment,
            IWxFansInfoAppService wxFansInfoAppService,
            ICategoryAppService categoryAppService)
        {
            _weChatAccountAppService = weChatAccountAppService;
            _webHostEnvironment = webHostEnvironment;
            _wxFansInfoAppService = wxFansInfoAppService;
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

                    OpenIdResultJson_Data data = resultJson.data;
                    List<BatchGetUserInfoData> infoData = new List<BatchGetUserInfoData>();
                    foreach (var _openid in data.openid)
                    {
                        infoData.Add(new BatchGetUserInfoData()
                        {
                            openid = _openid,
                            lang = "zh_CN"
                        });
                    }

                    if (infoData.Count > 0)
                    {
                        BatchGetUserInfoJsonResult result = await UserApi.BatchGetUserInfoAsync(accessToken, infoData);
                        List<UserInfoJson> users = result.user_info_list;
                        foreach (UserInfoJson info in users)
                        {
                            CreateWxFansInfoDto infoDto = new CreateWxFansInfoDto();
                            infoDto.weChaId = account.Id;
                            infoDto.openid = info.openid;
                            infoDto.city = info.city;
                            infoDto.headimgurl = info.headimgurl;
                            infoDto.language = info.language;
                            infoDto.nickname = info.nickname;
                            infoDto.province = info.province;
                            infoDto.sex = info.sex.ToString();
                            infoDto.subscribe_time = new DateTime(info.subscribe_time);
                            infoDto.country = info.country;
                            infoDto.unionid = info.unionid;
                            infoDto.groupid = info.groupid;
                            infoDto.qr_scene = info.qr_scene.ToString();
                            infoDto.qr_scene_str = info.qr_scene_str;
                            infoDto.remark = info.remark;
                            infoDto.subscribe = info.subscribe;
                            
                            await _wxFansInfoAppService.CreateFansAsync(infoDto);
                        }
                    }
                   
                }
                catch (Exception e)
                {
                    Logger.Error("获取粉丝信息失败",e);
                    return Json(new { code = "1", msg = "获取粉丝信息失败" });
                }
            }

            return Json(new {code="0", msg="获取成功"});
        }


    }
}
