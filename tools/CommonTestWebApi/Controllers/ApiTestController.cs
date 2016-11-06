using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommonTestWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ApiTestController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return id.ToString();
        }

        [HttpPost]
        public JsonResult Post(string p1, string p2)
        {
            return Json(new { p1, p2 });
        }

        [HttpGet]
        public IHeaderDictionary GetHttpHeaders()
        {
            return this.Request.Headers;
        }

        [HttpPost]
        public JsonResult FileUpload()
        {
            IFormFile file = this.Request.ReadFormAsync().Result.Files[0];
            if (file != null)
                return Json(new { ReturnCode = 0, FileName = file.FileName, Length = file.Length });
            else
                return Json(new { ReturnCode = -1 });
        }

        public FileResult FileDownload()
        {
            return File("", "");
        }
    }
}
