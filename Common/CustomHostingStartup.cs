
using Microsoft.AspNetCore.Hosting;
using NET6AndSkyWalking.Models;
[assembly: HostingStartup(typeof(CustomHostingStartup))]
namespace NET6AndSkyWalking.Models
{
    /// <summary>
    /// 必须实现IHostingStartup 接口
    /// 必须标记HostingStartup特性
    /// 发生在HostBuild时候，IOC容器初始化之前，无侵入式扩展
    /// </summary>
    public class CustomHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            Console.WriteLine("自定义扩展执行...");
            //拿到IWebHostBuilder,一切都可做
        }
    }
}
