using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiExplorerSettingsAttribute = Microsoft.AspNetCore.Mvc.ApiExplorerSettingsAttribute;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class UrlGenerationController : Controller
    {
        [HttpGet]
        public IActionResult Demo()
        {
            var url = Url.Action("Demo", "UrlGeneration", new { id = 17, color = "red" });
            //returns /Products/Buy/17?color=red.
            Console.WriteLine("---Demo:" + url);
            return Content("---Demo:" + url);            
        }

        //Use this attribute on an action or controller to hide it from document
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        public IActionResult Index02()
        {
            var url = Url.Action("Index2", "UrlGeneration", new { id = 17 }, protocol: Request.Scheme);
            Console.WriteLine("---Index2:" + url);
            // Returns https://localhost:5001/Products/Buy/17
            return Content("---Index2:"+url);
        }

        //public IActionResult Source()
        //{
        //    // Generates /UrlGeneration/Destination
        //    var url = Url.Action("Destination");
        //    return ControllerContext.MyDisplayRouteInfo("", $" URL = {url}");
        //}

        //public IActionResult Destination()
        //{
        //    return ControllerContext.MyDisplayRouteInfo();
        //}
    }
}
