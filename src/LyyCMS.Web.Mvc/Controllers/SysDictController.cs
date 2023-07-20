using Abp.AspNetCore.Mvc.Authorization;
using LyyCMS.Articles.Dtos;
using LyyCMS.Controllers;
using LyyCMS.SysManage;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;
using LyyCMS.Web.Models.SysManage;
using LyyCMS.Web.Models.SysMangae;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SysDictController : LyyCMSControllerBase
    {

        private readonly ISysDictAppService _appService;
        private readonly ISysDictItemAppService _sysDictItemAppService;

        public SysDictController(SysDictAppService appService,SysDictItemAppService sysDictItemAppService)
        {
            _appService = appService;
            _sysDictItemAppService = sysDictItemAppService;
        }

        public async Task<IActionResult> Index()
        {
            //GetSysDictInput dto = new GetSysDictInput();
            //dto.MaxResultCount = 10;
            //dto.SkipCount = 0;
            //var sysDictList = await _appService.GetPagedSysDictAsync(dto);

            return View();
        }

        public async Task<ActionResult> EditModal(int Id)
        {
            SysDictDto site = new SysDictDto();
            site.Id = Id;
            var output = await _appService.GetAsync(site);

            EditSysDictModalViewModel model = new EditSysDictModalViewModel()
            {
                SysDictDto = output
            };

            return PartialView("_EditModal", model);
        }


        protected List<ArticleCategoryListDto> sort(int parentId, List<ArticleCategoryListDto> itemCatsBeforeList, List<ArticleCategoryListDto> itemCatsAfterList)
        {
            foreach (ArticleCategoryListDto entity in itemCatsBeforeList)
            {
                if (entity.ParentId == parentId)
                {
                    itemCatsAfterList.Add(entity);
                    sort(entity.Id, itemCatsBeforeList, itemCatsAfterList);
                }
            }
            return itemCatsAfterList;
        }
    }
}
