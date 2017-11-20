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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(EmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //把对象转换成json字符串
            var json = JsonConvert.SerializeObject(model);
            return Content(json);
             
        }

        public IActionResult ValidateEmployeeNo(string employeeNo)
        {
            if (employeeNo == "007")
            {
                return Json(data: "007 is already assigned to James Bond!");
            }
            return Json(data: true);
        }


    }
}