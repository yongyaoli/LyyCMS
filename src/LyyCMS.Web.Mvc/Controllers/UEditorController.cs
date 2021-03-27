using LyyCMS.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEditor.Core;

namespace LyyCMS.Web.Controllers
{
    public class UEditorController : LyyCMSControllerBase
    {
        private readonly UEditorService _ueditorService;
        public UEditorController(UEditorService ueditorService)
        {
            this._ueditorService = ueditorService;
        }

        [HttpGet, HttpPost]
        public ContentResult Upload()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }
         
    }
}
