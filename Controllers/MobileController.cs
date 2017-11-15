using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Controllers
{
    public class MobileController : Controller
    {
        // http://localhost:57293/mobile
        public IActionResult Index()
        {
            var url = Url.Action("Index"); // /mobile
            return Content($"Mobile/Index (Url: {url})");
        }

        //http://localhost:57293/mobile/pageone
        public IActionResult PageOne()
        {
            var url = Url.Action("PageOne"); // /mobile/PageOne
            return Content($"Mobile/One (Url: {url})");
        }

        //http://localhost:57293/mobile/pagetwo
        [HttpGet]
        public IActionResult PageTwo()
        {
            var url = Url.Action("PageTwo"); //mobile/PageTwo
            return Content($"get, Mobile/Two (Url: {url})");
        }

        [HttpPost]
        public IActionResult PageTwo(int id)
        {
            var url = Url.Action("PageTwo"); // mobile/PageTwo/1
            return Content($"post, Mobile/Two: {id} (Url: {url})");
        }

        //http://localhost:57293/mobile/pagethree
        public IActionResult PageThree()
        {
            var url = Url.RouteUrl("goto_two", new { id=5}); // two/5
            return Content($"Mobile/Three (Url: {url})");
        }

        //http://localhost:57293/mobile/pagefour
        public IActionResult PageFour()
        {
            var url = Url.RouteUrl("goto_two", new { q=5}); //two?q=5 模板中没有规定的参数出现在查询字符串中
            return Content($"Mobile/Four (Url: {url})");
        }

        //http://localhost:57293/mobile/PageSix
        public IActionResult PageFive()
        {
            return RedirectToAction("PageSix");
        }

        public IActionResult PageSix()
        {
            return Content("Mobile/Six (Mobile/Five will also come here)");
        }
    }
}