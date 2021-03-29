using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Controllers;
using LyyCMS.Members;
using LyyCMS.Members.Dtos;
using LyyCMS.Web.Models.Members;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class MemberController : LyyCMSControllerBase
    {

        private readonly IMembersAppService _membersAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryAppService _categoryAppService;

        public MemberController(IMembersAppService membersAppService, 
            IWebHostEnvironment webHostEnvironment,
            ICategoryAppService categoryAppService)
        {
            _membersAppService = membersAppService;
            _webHostEnvironment = webHostEnvironment;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index(GetMemberInput input)
        {
            var CategoryList = (await _categoryAppService.GetPagedAllCategoryAsync()).Items;
            var model = new MemberListViewModel
            {
                Categories = CategoryList
            };
            return View(model);
        }


    }
}
