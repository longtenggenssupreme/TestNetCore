using System;
using System.Collections.Generic;
using System.Text;

namespace TestNetCore
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        CreateWebHostBuilder(args).Build().Run();
    //    }

    //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //        WebHost.CreateDefaultBuilder(args)
    //        .ConfigureLogging((context, loggingbuilder) =>
    //        {
    //            //该方法需要引入Microsoft.Extensions.Logging名称空间
    //            loggingbuilder.AddFilter("System", LogLevel.Warning); //过滤掉系统默认的一些日志
    //            loggingbuilder.AddFilter("Microsoft", LogLevel.Warning);//过滤掉系统默认的一些日志

    //            //添加Log4Net
    //            //var path = Directory.GetCurrentDirectory() + "\\log4net.config"; 
    //            //不带参数：表示log4net.config的配置文件就在应用程序根目录下，也可以指定配置文件的路径，
    //            //但是在log4net.config文件中就不需要添加configuration标签了
    //            loggingbuilder.AddLog4Net();//其他地方使用构造函数依赖注入就可以了,例如： ILogger<HomeController> logger
    //        })
    //        .UseStartup<Startup>();
    //}
}
