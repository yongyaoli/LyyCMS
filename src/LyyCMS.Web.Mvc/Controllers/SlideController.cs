using Abp.Application.Services.Dto;
using LyyCMS.Controllers;
using LyyCMS.Slides;
using LyyCMS.Slides.Dtos;
using LyyCMS.Web.Models.Slide;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
