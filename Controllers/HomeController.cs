using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Home/Index");
        }

        //http://localhost:57293/Home/PageOne
        //http://localhost:57293/one
        public IActionResult PageOne()
        {
            return Content("Home/PageOne");
        }

        //http://localhost:57293/Home/PageTwo
        //http://localhost:57293/two
        //http://localhost:57293/two/1
        [HttpGet]
        public IActionResult PageTwo()
        {
            return Content("get, Home/PageTwo");
        }

        [HttpPost]
        public IActionResult PageTwo(int id)
        {
            return Content($"post, Home/PageTwo:{id}");
        }
    }
}