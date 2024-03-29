﻿using LyyCMS.Controllers;
using LyyCMS.Slides;
using LyyCMS.Slides.Dtos;
using LyyCMS.Web.Models.Slide;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LyyCMS.Web.Controllers
{
    public class SlideController : LyyCMSControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISlideAppService _slideAppService;

        public SlideController(
            IWebHostEnvironment webHostEnvironment,
            ISlideAppService slideAppService)
        {
            _webHostEnvironment = webHostEnvironment;
            _slideAppService = slideAppService;

        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> EditModal(int Id)
        {
            SlideListDto slide = new SlideListDto();
            slide.Id = Id;
            var output = await _slideAppService.GetAsync(slide);
            var model = ObjectMapper.Map<EditSlideModalViewModel>(output);

            return PartialView("_EditModal", model);
        }

        /// <summary>
        /// 图片
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Items(int Id)
        {
            SlideListDto slide = new SlideListDto();
            slide.Id = Id;
            var output = await _slideAppService.GetAsync(slide);
            SlideListViewModel slideListViewModel = new SlideListViewModel();
            slideListViewModel.Slide = output;
            slideListViewModel.SlideItems = output.SlideItems;
            return View(slideListViewModel);
        }
    }
}
