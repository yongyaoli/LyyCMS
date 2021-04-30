using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Authorization;
using LyyCMS.Controllers;
using LyyCMS.Users;
using LyyCMS.Web.Models.Users;
using Abp.Web.Models;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : LyyCMSControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UsersController(IUserAppService userAppService, IWebHostEnvironment webHostEnvironment)
        {
            _userAppService = userAppService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ActionResult> Index()
        {
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Roles = roles
            };
            return View(model);
        }

        public async Task<ActionResult> EditModal(long userId)
        {
            var user = await _userAppService.GetAsync(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return PartialView("_EditModal", model);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }


        public virtual async Task<JsonResult> UploadAvatar()
        {
            #region 单个文件上传
            //string webPath = _hostingEnvironment.ContentRootPath; //mvc 路径

            string rootPath = _webHostEnvironment.WebRootPath;
            
            var file = Request.Form.Files[0];
            var extension = Path.GetExtension(file.FileName);
            //类型判断 TODO 需要做一个检测工具
            if (!(".jpg".Equals(extension) || ".jpeg".Equals(extension) || ".png".Equals(extension)))
            {
                return Json(new AjaxResponse { Success = false, Result = "文件类型错误" });
            }

            //TODO 路径需要写到配置文件中
            string shortTime = "upload/"+ DateTime.Now.ToString("yyyy/MM/dd") + "/";
            string filePhysicalPath = Path.Combine(rootPath, shortTime);
            if (!Directory.Exists(filePhysicalPath)) //判断上传文件夹是否存在，若不存在，则创建
            {
                Directory.CreateDirectory(filePhysicalPath); //创建文件夹
            }
            string fileName = System.Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(shortTime, fileName);
            string fullPath = Path.Combine(rootPath, filePath);
            using (FileStream fs = System.IO.File.Create(fullPath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            #endregion
            return Json(new AjaxResponse { Success = true, Result= filePath });
        }
    }
}
