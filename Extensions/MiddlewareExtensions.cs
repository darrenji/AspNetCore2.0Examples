﻿using Microsoft.AspNetCore.Builder;
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
    }
}
