using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Examples.Models;

namespace Examples.Controllers
{
    //Routing middleware会把http请求拆分，从template中接受值，保存到RouteData中，然后再把RouteData中的数据与action数据进行绑定
    //model binding根据惯例，使用反射，绑定过程不抛异常
    //[BindRequired]如果绑定失败，就添加model state
    //[BindNever]忽视绑定
    //[FromHeader]
    //[FromQuery]
    //[FromRoute]
    //[FromForm]
    //[FromService]
    //[FromBody]
    //[ModelBinder]自定义model binder
    //模型绑定来源的顺序是：Form>Route>Query
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<MovieViewModel> model = GetMovies();
            return View(model);
        }

        public IActionResult Details(MovieInputModel model)
        {
            return Content(model.Id);
        }

        public List<MovieViewModel> GetMovies()
        {
            return new List<MovieViewModel>
            {
                new MovieViewModel{Id="1", Title="never say never again", ReleaseYear=1983, Summary="it's a summary"},
                new MovieViewModel{Id="2", Title="diamonds are forever", ReleaseYear=1971, Summary="a diamond sumgggling"},
                new MovieViewModel{Id="3", Title="you only live twice", ReleaseYear=1967, Summary="agent 007 and the sea"}
            };
        }
    }
}