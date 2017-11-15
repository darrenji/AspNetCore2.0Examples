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
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //前端还有一个TagHelper <environment include="Development"></evironment>
            //可以在属性-调试中设置ASPNETCORE_ENVIRONMENT变量
            //根据ASPNETCORE_ENVIRONMENT不同的设置来决定使用哪些中间件，比如在Development的时候使用exception pages有关的中间件，下载不同的Javascript和CSS文件，读出不同的配置
           if(env.IsDevelopment())
            {
                
            }
           else if(env.IsStaging())
            {

            }
           else if(env.IsProduction())
            {

            }
           else
            {

            }
        }

       
    }
}
