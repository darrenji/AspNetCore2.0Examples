using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Controllers
{
    [Route("work")]
    public class WorkController : Controller
    {
        //http://localhost:57293/work/
        public IActionResult Index()
        {
            return Content("Work/Index");
        }

        //http://localhost:57293/work/one
        [Route("one")]
        public IActionResult PageOne()
        {
            return Content("Work/PageOne");
        }

        //http://localhost:57293/work/two
        [HttpGet("two")]
        public IActionResult PageTwo()
        {
            return Content("get, Work/PageTwo");
        }

        [HttpPost("two/{id?}")]
        public IActionResult PageTwo(int id)
        {
            return Content($"post, Work/PageTwo:{id}");
        }
    }
}