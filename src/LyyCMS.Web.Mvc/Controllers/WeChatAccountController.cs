﻿using Abp.AspNetCore.Mvc.Authorization;
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
    }
}
