using LyyCMS.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEditor.Core;

namespace LyyCMS.Web.Controllers
{
    public class UploadController : LyyCMSControllerBase
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UEditorService _ueditorService;
        public UploadController(UEditorService ueditorService, IWebHostEnvironment webHostEnvironment)
        {
            this._ueditorService = ueditorService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet, HttpPost]
        public ContentResult New()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }

        [HttpGet, HttpPost]
        public ContentResult uploadimage()
        {
            string s = "";

            string rootPath = _webHostEnvironment.WebRootPath;

            var file = Request.Form.Files[0];


            return Content("");
        }


        [HttpGet, HttpPost]
        public ContentResult Kind()
        {
            string s = "";

            string rootPath = _webHostEnvironment.WebRootPath;


            return Content("");
        }

        [HttpGet, HttpPost]
        public ContentResult KindFileManager()
        {
            return Content("");
        }

    }
}
