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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //IApplicationBuilder有Run,Use, UseMiddleware,Map方法，其中Map方法用来映射请求路径和中间件
            //Run方法接受的类型为RequestDelegate,因此有了对HttpContext的控制，返回void类型意味着请求从这里返回给客户端
            //Use方法接受HttpContext,并且有一个指向下一个中间件的指针
            //UseMiddleware,当我们把中间件封装成一个类的时候使用此方法
            //中间件的使用顺序和Configure方法中的先后顺序对应
            app.UseHelloWorldInClass();
            app.RunHelloWorld();
        }

       
    }
}
