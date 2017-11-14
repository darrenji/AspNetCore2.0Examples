using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Examples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //让IWebHost运行
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            //WebHost.CreateDefaultBuilder是工厂模式，创建IWebHostBuilder
            //IWebHostBuilder有一个UseSetting方法，用来进行一些基本设置，比如applicationName, contentRoot, detailedErrors, environment, urls, webroot
            //创建IWebHostBuilder的过程，使用到了cross-platform web server Kestrel, 设置根路径，把当前的项目文件设置为根路径
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
