using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Extensions
{
    public class HelloFileProviderMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IFileProvider fileProvider;

        public HelloFileProviderMiddleware(RequestDelegate next, IFileProvider fileProvider)
        {
            this.next = next;
            this.fileProvider = fileProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            IFileInfo file = this.fileProvider.GetFileInfo("Startup.cs");

            using (var stream = file.CreateReadStream())
            using (var reader = new StreamReader(stream))
            {
                var output = await reader.ReadToEndAsync();
                await context.Response.WriteAsync(output.ToString());
            }
        }
    }
}
