using Abp.Application.Services.Dto;
using LyyCMS.Articles;
using LyyCMS.Controllers;
using LyyCMS.Web.Models.Articles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using LyyCMS.Articles.Dtos;

namespace LyyCMS.Web.Controllers
{
    public class ArticleCategoryController : LyyCMSControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IArticleCategoryAppService _categoryAppService;

        public ArticleCategoryController(
            IWebHostEnvironment webHostEnvironment,
            IArticleCategoryAppService categoryAppService)
        {
            _webHostEnvironment = webHostEnvironment;
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index()
        {
            var articleCategories = await _categoryAppService.GetAllArticleCategoryListAsync();
            var model = new ArticleCategoryListViewModel
            {
                ParentCategoryList = articleCategories
            };

            

            return View(model);
        }

        public async Task<ActionResult> EditModal(int id)
        {
            var articleCategory = await _categoryAppService.GetAsync(new EntityDto<int>(id));

            PagedArticleCategoryResultRequestDto dto = new PagedArticleCategoryResultRequestDto();
            dto.MaxResultCount = int.MaxValue;
            var all = await _categoryAppService.GetAllAsync(dto);
            var allList = all.Items.Where(x => x.Id != id).ToList();

            var model = new EditArticleCategoryModalViewModel
            {
                ArticleCategory = articleCategory,
                Parents = allList
            };
            return PartialView("_EditModal", model);
        }
    }
}
