using LyyCMS.Articles;
using LyyCMS.Controllers;
using LyyCMS.Web.Models.Articles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

            var articleCategories = (await _categoryAppService.GetAllArticleCategoryListAsync());
            var model = new ArticleCategoryListViewModel
            {
                ParentCategoryList = articleCategories
            };

            return View(model);
        }
    }
}
