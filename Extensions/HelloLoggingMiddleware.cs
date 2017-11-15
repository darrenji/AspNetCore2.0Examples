using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Extensions
{
    public class HelloLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<HelloLoggingMiddleware> logger;

        public HelloLoggingMiddleware(RequestDelegate next, ILogger<HelloLoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var message = new {
                GreetingTo = "james",
                GreetingTime="morning",
                GreetingTyp = "good"
            };

            this.logger.LogInformation("inoke executing {@message}", message);
            await context.Response.WriteAsync("hello logging");
            this.logger.LogInformation("invoke executed by {developer} at {time}", "darren", DateTime.Now);
        }
    }
}
