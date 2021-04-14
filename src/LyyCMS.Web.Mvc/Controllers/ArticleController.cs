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
        public async Task<IActionResult> Create()
        {
            var allCategory = await _categoryAppService.GetAllArticleCategoryListAsync();
            EditArticleModalViewModel model = new EditArticleModalViewModel()
            {
                Article =  new ArticleDto(),
                ArticleCategory = allCategory
            };
            return View(model);
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
        public async Task<IActionResult> Edit(int id)
        {
            ArticleListDto articleDto = new ArticleListDto();
            articleDto.Id = id;
            var article = await _articleAppService.GetAsync(articleDto);
            var allCategory = await _categoryAppService.GetAllArticleCategoryListAsync();
            EditArticleModalViewModel model = new EditArticleModalViewModel()
            {
                Article = article,
                ArticleCategory = allCategory
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                var x = collection;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> EditModal(int id)
        {
            ArticleListDto articleDto = new ArticleListDto()
            {
                Id = id
            };
            var article = await _articleAppService.GetAsync(articleDto);
            var allCategory = await _categoryAppService.GetAllArticleCategoryListAsync();
            var model = new EditArticleModalViewModel
            {
                Article = article,
                ArticleCategory = allCategory
            };
            return PartialView("_EditModal", model);
        }
         
    }
}
