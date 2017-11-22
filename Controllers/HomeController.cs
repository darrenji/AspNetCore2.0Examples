﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examples.Models.Home;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examples.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new EmployeeViewModel
            {
                Id = 1,
                Firstname = "darren",
                Surname = "ji"
            };
            return View(model);
        }
    }
}
