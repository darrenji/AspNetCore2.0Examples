using Examples.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        private readonly AppSettings settings;

        public HelloWorldMiddleware(RequestDelegate next, IOptions<AppSettings> options)
        {
            this.next = next;
            this.settings = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {

            var jsonsettings = JsonConvert.SerializeObject(this.settings);
            await context.Response.WriteAsync(jsonsettings);
        }
    }
}
