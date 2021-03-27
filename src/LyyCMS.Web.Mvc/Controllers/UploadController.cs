using LyyCMS.Controllers;
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


        private readonly UEditorService _ueditorService;
        public UploadController(UEditorService ueditorService)
        {
            this._ueditorService = ueditorService;
        }

        [HttpGet, HttpPost]
        public ContentResult New()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }

        [HttpGet, HttpPost]
        public ContentResult Kind()
        {
            


            return Content("");
        }

        [HttpGet, HttpPost]
        public ContentResult KindFileManager()
        {
            return Content("");
        }

    }
}
