using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyFlatWEB.Areas.Management.ManagementHostingStartup))]
namespace MyFlatWEB.Areas.Management
{
    public class ManagementHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
