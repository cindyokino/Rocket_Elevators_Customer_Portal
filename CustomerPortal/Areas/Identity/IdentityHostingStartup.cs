using System;
using CustomerPortal.Areas.Identity.Data;
using CustomerPortal.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CustomerPortal.Areas.Identity.IdentityHostingStartup))]
namespace CustomerPortal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DbCustomerPortalContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DbCustomerPortalContextConnection")));

                services.AddDefaultIdentity<CustomerPortalUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DbCustomerPortalContext>();
            });
        }
    }
}