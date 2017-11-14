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
        public static void RunHelloWorld(this IApplicationBuilder app)
        {
            app.Run(async (context) => {
                await context.Response.WriteAsync("hello world from extension method");
            });
        }

        public static IApplicationBuilder UseHelloWorld(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) => {
                await context.Response.WriteAsync("hello world using use");
                await next();
            });
        }
    }
}
