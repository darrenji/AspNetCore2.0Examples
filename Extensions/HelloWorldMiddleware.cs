using Examples.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Extensions
{
    /// <summary>
    /// 中间件的本质是接受RequestDelegate,然后把HttpContext交给RequestDelegate继续往前走
    /// </summary>
    public class HelloWorldMiddleware
    {
        private readonly RequestDelegate next;

        public HelloWorldMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IGreetingService greetingService)
        {

            var message = greetingService.Greet("darren");
            await context.Response.WriteAsync(message);
        }
    }
}
