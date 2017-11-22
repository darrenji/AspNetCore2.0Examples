using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examples.Controllers
{
    public class ComponentsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Content("Use /Address or /UserInfo");
        }

        public IActionResult UserInfo()
        {
            //到Views/Shared中去找，找到
            return ViewComponent("UserInfo");
        }

        public IActionResult Address()
        {
            //到Views/Shared中去找,找不到
            return ViewComponent("Address", new { employeeId = 5 });
        }
    }
}
