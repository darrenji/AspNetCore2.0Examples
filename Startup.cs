using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Examples.Extensions;
using Examples.Models;
using Examples.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Examples
{
    public class Startup
    {
        public static IConfiguration Config { get; private set; }

        public Startup(IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IConfiguration config)
        {
            Config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(factory => {
                var actionContext = factory.GetService<IActionContextAccessor>().ActionContext;
                return new UrlHelper(actionContext);
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvc(routes => {
                //路由名称为goto_one,模板one，来到Home控制器的PageOne下
                routes.MapRoute(
                    name: "goto_one",
                    template: "one",
                    defaults: new { controller="Home", action="PageOne"});

                routes.MapRoute(
                    name:"goto_two",
                    template:"two/{id?}",
                    defaults: new { controller="Home",action="PageTwo"});

                routes.MapRoute(
                    name:"default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

       
    }
}
