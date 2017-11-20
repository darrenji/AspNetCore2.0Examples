using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examples.Models;
using Newtonsoft.Json;

namespace Examples.Controllers
{
    //模型验证在什么时候发生？在模型绑定之后，在Action真正执行之前
    //ModelState属性来自ControllerBase
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            var model = new AboutViewModel
            {
                Firstname = "Darren",
                Surname = "Ji"
            };
            return View("Bio", model);
        }

    }
}