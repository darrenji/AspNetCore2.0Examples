using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examples.Models;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examples.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            var model = new EmployeesViewModel {
                Employees = new List<Employee> {
                    new Employee
                    {
                        Name="darren",
                        JobTitle="ceo",
                        Profile="excellent",
                        Friends=new List<Friend>
                        {
                            new Friend{Name="tom"},
                            new Friend{ Name="dick"},
                            new Friend{ Name="harry"}
                        }
                    },
                    new Employee{
                        Name="james",
                        JobTitle="ceo",
                        Profile="good",
                        Friends=new List<Friend>
                        {
                            new Friend{Name="james gordon"},
                            new Friend{Name="robin hood"}
                        }
                    }
                }
            };
            return View(model);
        }

        public IActionResult Movie()
        {
            var model = new MovieViewModel {
                Title ="diamonds",
                ReleaseYear="1971",
                Director="guy",
                Summary="pretty good",
                Starts = new List<string> { "sean", "jill st"}
            };
            return View(model);
        }

        public IActionResult Context()
        {
            ViewBag.Greeting = "hello from view bag";
            return View();
        }

        public IActionResult Greet()
        {
            return View();
        }
    }
}
