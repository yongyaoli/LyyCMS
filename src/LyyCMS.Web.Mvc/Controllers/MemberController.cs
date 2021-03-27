using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Controllers;
using LyyCMS.Members;
using LyyCMS.Members.Dtos;
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

        public MemberController(IMembersAppService membersAppService, IWebHostEnvironment webHostEnvironment)
        {
            _membersAppService = membersAppService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(GetMemberInput input)
        {
            var dtos = await _membersAppService.GetPagedMemeberAsync(input);

            return View(dtos);
        }


    }
}
