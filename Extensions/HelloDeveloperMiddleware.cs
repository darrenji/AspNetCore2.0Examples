using Examples.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Extensions
{
    /// <summary>
    /// 在HttpContext中获取到服务
    /// </summary>
    public class HelloDeveloperMiddleware
    {
        private readonly RequestDelegate next;

        public HelloDeveloperMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        //public async Task Invoke(HttpContext context)
        //{
        //    var greetingService = (IGreetingService)context.RequestServices.GetService(typeof(IGreetingService));
        //    var message = greetingService.Greet("developers");
        //    await context.Response.WriteAsync(message);
        //}
    }
}
