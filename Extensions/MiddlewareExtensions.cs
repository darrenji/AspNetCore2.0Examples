using Examples.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Extensions
{
    public static class MiddlewareExtensions
    {
        #region HelloWorld中间件
        //Run方法使用中间件
        public static void RunHelloWorld(this IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("hello world from extension method");
            });
        }

        /// <summary>
        /// Use方法使用中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello world using use");
                await next();
            });
        }


        /// <summary>
        /// UseMiddleware方法使用中间件类
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseHelloWorldInClass(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HelloWorldMiddleware>();
        }
        #endregion
        #region Greeting中间件

        /// <summary>
        /// UseMiddleware也可以传递中间件的参数
        /// </summary>
        /// <param name="app"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGreeting(this IApplicationBuilder app, GreetingOptions options)
        {
            return app.UseMiddleware<GreetingMiddleware>(options);
        } 

        public static IApplicationBuilder UseGreeing1(this IApplicationBuilder app, Action<GreetingOptions> configureOptions)
        {
            var options = new GreetingOptions();
            configureOptions(options);
            return app.UseMiddleware<GreetingMiddleware>(options);
        }
        #endregion
    }
}
