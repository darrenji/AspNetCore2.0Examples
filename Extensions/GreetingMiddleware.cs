using Examples.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Extensions
{
    public class GreetingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly GreetingOptions options;

        public GreetingMiddleware(RequestDelegate next, GreetingOptions options)
        {
            this.next = next;
            this.options = options;
        }

        public async Task Invoke(HttpContext context)
        {
            var message = $"Good {this.options.GreetAt} {this.options.GreetTo}";
            await context.Response.WriteAsync(message);
        }
    }
}
