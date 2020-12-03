using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tomi_Ionel_Lab2.Models;

[assembly: HostingStartup(typeof(Tomi_Ionel_Lab2.Areas.Identity.IdentityHostingStartup))]
namespace Tomi_Ionel_Lab2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentifyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentifyContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentifyContext>();
            });
        }
    }
}