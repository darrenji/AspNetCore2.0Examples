using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examples.Models;

namespace Examples.Controllers
{
    //模型验证在什么时候发生？在模型绑定之后，在Action真正执行之前
    //ModelState属性来自ControllerBase
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("hello model validation");
        }

        [HttpPost]
        public IActionResult Save(EmployeeInputModel model)
        {
            if(model.Id ==1)
            {
                ModelState.AddModelError("Id", "Id already exist");
            }

            if(ModelState.IsValid)
            {
                return Ok(model);
            }

            return BadRequest(ModelState);
        }
    }
}