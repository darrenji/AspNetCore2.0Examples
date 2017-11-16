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
        #region simple，来源可以是route, query, form
        //from route, query, form
        public IActionResult Simple(int id)
        {
            return Content($"Simple (id: {id})");
        }

        //from query
        public IActionResult SimpleQuery([FromQuery]int id)
        {
            return Content($"SimpleQuery (id: {id})");
        }

        //from from
        public IActionResult SimpleForm([FromForm]int id)
        {
            return Content($"SimpleForm (id: {id})");
        }

        //from body
        public ActionResult SimpleBodyWithoutModel([FromBody]int id)
        {
            return Content($"SimpleBodyWthoutModel (id: {id})");
        }

        //from body get model
        public IActionResult SimpleBodyWithModel([FromBody]SimpleBodyInputModel model)
        {
            return Content($"SimpleBodyWithModel (id: {model.Id})");
        }

        public IActionResult SimpleHeader([FromHeader]string host, [FromHeader(Name = "User-Agent")]string userAgent)
        {
            return Content($"SimpleHeader (host: {host},userAgent: {userAgent})");
        } 
        #endregion

        #region complex,来源不可以是route,可以是query, form
        //complex from query, form
        public IActionResult Complex(GreetingInputModel model)
        {
            return Content($"Complex (type: {model.Type}, to: {model.To})");
        }

        //complex from query
        public IActionResult ComplexQuery([FromQuery]GreetingInputModel model)
        {
            return Content($"ComplexQuery (type: {model.Type}, to: {model.To})");
        }

        //complext from form
        public IActionResult ComplexForm([FromForm]GreetingInputModel model)
        {
            return Content($"ComplexForm (type: {model.Type}, to: {model.To})");
        }

        //complex from body
        public IActionResult ComplexBody([FromBody]GreetingInputModel model)
        {
            return Content($"ComplexBody (type: {model.Type}, to: {model.To})");
        }

        //complex from header
        public IActionResult ComplexHeader([FromHeader]GreetingInputModel model)
        {
            return Content($"ComplexHeader (type: {model.Type}, to: {model.To})");
        }
        #endregion

        #region collections
        //collection from query
        public IActionResult Collection(IEnumerable<string> values)
        {
            return Content($"Collection (count: {values.Count()})");
        }

        //collecton from body
        public IActionResult CollectionComplex([FromBody]CollectionInputModel model)
        {
            return Content($"CollectionComplex (count: {model.values.Count()})");
        }
        #endregion

        #region from multiple sources
        //from route, query
        public IActionResult Multiple(int id)
        {
            return Content($"Multiple: {id}");
        }
        #endregion
    }
}