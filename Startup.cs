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
        public Startup(IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IConfiguration config)
        {
            
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //所有的ConfigureServices运行在Configure之前
            //MVC也是中间件
            //AddScoped()每一次请求产生服务实例
            //AddTransient()每一个实例都是不一样的
            //AddSingleton()从第一次请求到最后实例搜是一样的
            //IServiceCollectioin.AddDbContext背后也用到了AddScoped()
            //IServiceCollection有关的方法包括：AddDbContext, AddIdentity, AddOptions, AddMvc
            services.AddScoped<IGreetingService>(factory => {
                return new FlexibleGreetingService("hi");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseGreeting2();
        }

       
    }
}
