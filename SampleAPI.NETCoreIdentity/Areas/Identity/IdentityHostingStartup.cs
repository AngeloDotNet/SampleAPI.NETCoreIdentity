using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleAPI.NETCoreIdentity.Data;

[assembly: HostingStartup(typeof(SampleAPI.NETCoreIdentity.Areas.Identity.IdentityHostingStartup))]
namespace SampleAPI.NETCoreIdentity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("DbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DbContext>();
            });
        }
    }
}
