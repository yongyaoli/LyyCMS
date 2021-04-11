using Abp.Application.Services.Dto;
using LyyCMS.Articles;
using LyyCMS.Articles.Dtos;
using LyyCMS.Controllers;
using LyyCMS.Web.Models.Articles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
    public class ArticleController : LyyCMSControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IArticleAppService _articleAppService;
        private readonly IArticleCategoryAppService _categoryAppService;

        public ArticleController(
            IWebHostEnvironment webHostEnvironment,
            IArticleAppService articleAppService,
            IArticleCategoryAppService categoryAppService
            )        
        {
            _webHostEnvironment = webHostEnvironment;
            _articleAppService = articleAppService;
            _categoryAppService = categoryAppService;
        }

        // GET: ArticleController
        public async Task<IActionResult> Index()
        {
            var articleCategories = await _categoryAppService.GetAllArticleCategoryListAsync();
            var model = new ArticleListViewModel
            {
                CategoryList = articleCategories
            };

            return View(model);
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int id)
        {
            var article = await _articleAppService.GetAsync(new EntityDto<int>(id));

            PagedArticleCategoryResultRequestDto dto = new PagedArticleCategoryResultRequestDto();
            dto.MaxResultCount = int.MaxValue;
            var allCategory = await _categoryAppService.GetAllAsync(dto);

            var model = new EditArticleModalViewModel
            {
                Article = article,
                ArticleCategory = allCategory.Items
            };
            return PartialView("_EditModal", model);
        }
         
    }
}
