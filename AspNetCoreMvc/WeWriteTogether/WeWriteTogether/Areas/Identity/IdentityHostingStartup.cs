using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(WeWriteTogether.Areas.Identity.IdentityHostingStartup))]
namespace WeWriteTogether.Areas.Identity
{
  public class IdentityHostingStartup : IHostingStartup
  {
    public void Configure(IWebHostBuilder builder)
    {
      builder.ConfigureServices((context, services) =>
      {
        services.AddTransient<IEmailSender, EmailSender>();
      });
    }
  }
}