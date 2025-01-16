using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MyFlatWEB.Areas.Identity.IdentityHostingStartup))]
namespace MyFlatWEB.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}