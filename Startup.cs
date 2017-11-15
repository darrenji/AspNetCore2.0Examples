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
            //内部读取appsettings.json, appsettings.Development.json
            services.AddOptions();
            //内部使用Config["Seciton1.SettingA"]读取内容填充到AppSettings中
            //也可以写成：services.Configure(Config.GetSection("Section1"))
            //或者写成：services.Configure(options=>{options.Section1.SettingA = "somevalue"})
            services.Configure<AppSettings>(Config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseGreeting2();
        }

       
    }
}
