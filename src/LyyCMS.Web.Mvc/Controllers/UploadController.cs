using LyyCMS.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
            string rootPath = _webHostEnvironment.WebRootPath;

            var file = Request.Form.Files[0];


            return Content("");
        }


        [HttpGet, HttpPost]
        public ContentResult Kind()
        {

            string rootPath = _webHostEnvironment.WebRootPath;

            return Content("");
        }

        [HttpGet, HttpPost]
        public ContentResult KindFileManager()
        {
            return Content("");
        }

        /// <summary>
        /// Kindeditor图片上传
        /// </summary>
        /// <param name="imgFile">Kindeditor图片上传自带的命名，不可更改名称</param>
        /// <param name="dir">不可更改名称 这里没有用到dir</param>
        /// <returns></returns>
        public IActionResult KindeditorPicUpload(IList<IFormFile> imgFile, string dir)
        {
            PicUploadResponse rspJson = new PicUploadResponse() { error = 0, url = "/upload/" };
            long size = 0;
            string tempname = "";
            foreach (var file in imgFile)
            {
                var filename = ContentDispositionHeaderValue
                    .Parse(file.ContentDisposition)
                    .FileName
                    .Trim('"');
                var extname = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                var filename1 = System.Guid.NewGuid().ToString() + extname;
                tempname = filename1;
                var path = _webHostEnvironment.WebRootPath;
                filename = _webHostEnvironment.WebRootPath + $@"\upload\{filename1}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                    //这里是业务逻辑
                }
            }
            rspJson.error = 0;
            rspJson.url = $@"../../upload/" + tempname;
            return Json(rspJson);
        }
        
    }
    public class PicUploadResponse
    {
        public int error { get; set; }
        public string url { get; set; }
    }
}

