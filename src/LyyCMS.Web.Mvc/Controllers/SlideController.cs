using LyyCMS.Controllers;
using LyyCMS.Slides;
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
    }
}
