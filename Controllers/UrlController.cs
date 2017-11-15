using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Controllers
{
    [Route("url")]
    public class UrlController : Controller
    {
        private readonly IUrlHelper urlHelper;

        public UrlController(IUrlHelper urlHelper)
        {
            this.urlHelper = urlHelper;
        }

        //http://localhost:57293/url
        public IActionResult Index()
        {
            var links = new List<string>();
            links.Add(this.urlHelper.RouteUrl("goto_one", new { })); // /one
            links.Add(this.urlHelper.Action("PageOne", "Home", new { })); // /one, 这里显示的不是/Home/PageOne,显示的是模板，有模板的时候显示模板
            links.Add(this.urlHelper.Link("goto_one", new { })); // http://localhost:57293/one
            return Json(links);
        }
    }
}