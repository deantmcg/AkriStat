using AkriStat.Areas.Identity.Data;
using AkriStat.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AkriStat.Areas.Identity.IdentityHostingStartup))]
namespace AkriStat.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Dev")));

                services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
                {
                    //options.SignIn.RequireConfirmedEmail = true;
                })
                    .AddDefaultTokenProviders()
                    .AddDefaultUI()
                    .AddRoles<ApplicationRole>()
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}