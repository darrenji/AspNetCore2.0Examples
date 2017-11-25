using Examples.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Filters
{
    public class AddDeveloperResultFilter : IResultFilter
    {
        private readonly string developer;

        public AddDeveloperResultFilter(string developer)
        {
            this.developer = developer;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //把信息写到了响应的Headers中了
            context.HttpContext.Response.Headers.Add("Developer", new StringValues(this.developer));
        }
    }

    public class GreetDeveloperResultFilter : IResultFilter
    {
        private readonly IGreetingService greetingService;

        public GreetDeveloperResultFilter(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
           
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("Developer-Msg", new StringValues(this.greetingService.Greet("darren")));
        }
    }
}
