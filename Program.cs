using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Examples
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                //让IWebHost运行
                BuildWebHost(args).Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IWebHost BuildWebHost(string[] args) =>
            //WebHost.CreateDefaultBuilder是工厂模式，创建IWebHostBuilder
            //IWebHostBuilder有一个UseSetting方法，用来进行一些基本设置，比如applicationName, contentRoot, detailedErrors, environment, urls, webroot
            //创建IWebHostBuilder的过程，使用到了cross-platform web server Kestrel, 设置根路径，把当前的项目文件设置为根路径
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, builder) => {
                    builder.AddConsole();
                    builder.AddDebug();
                })
                .UseStartup<Startup>()
                .UseSerilog()
                .Build();
    }
}
