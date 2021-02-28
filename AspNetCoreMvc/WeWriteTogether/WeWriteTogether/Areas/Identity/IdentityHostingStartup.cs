using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using WeWriteTogether.Data;

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

        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();

        services.AddAuthentication()
          .AddGoogle(o =>
          {
            o.ClientId = context.Configuration["Google:ClientId"];
            o.ClientSecret = context.Configuration["Google:ClientSecret"];
          });
      });
    }
  }
}
