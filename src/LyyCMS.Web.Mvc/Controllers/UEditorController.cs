using LyyCMS.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using UEditor.Core;

namespace LyyCMS.Web.Controllers
{
    public class UEditorController : LyyCMSControllerBase
    {
        private readonly UEditorService _ueditorService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UEditorController(UEditorService ueditorService, IWebHostEnvironment webHostEnvironment)
        {
            this._ueditorService = ueditorService; 
            this._webHostEnvironment = webHostEnvironment;
        }

        [HttpGet, HttpPost]
        public ContentResult Upload()
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
    }
}
