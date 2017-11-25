using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using Examples.Filters;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examples.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        #region Action Filters
        [SkipActionFilter]
        public IActionResult SkipAction()
        {
            return Content("Home/SkipAction");
        }

        [ParseParameterFilter]
        public IActionResult ParseParameter(string param)
        {
            return Content($"Home/ParseParameter, param:{param}");
        }
        #endregion

        #region Result Filters
        [SkipResultFilter]
        public IActionResult SkipResult()
        {
            return Content("Home/SkipResult");
        }

        [AddVersionResultFilter("ASP.NET Core MVC 2.0")]
        public IActionResult AddVersion()
        {
            return Content("Home/AddVersion");
        }
        #endregion

        #region Type Filters
        [TypeFilter(typeof(GreetingTypeFilter))]
        public IActionResult GreetType1(string param)
        {
            return Content($"Hello/GreetType1, param:{param}");
        }

        [GreetingTypeFilterWrapper]
        public IActionResult GreetType2(string param)
        {
            return Content($"Home/GreetType2,, param:{param}");
        }
        #endregion
    }
}
