using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Azure.Identity;


namespace CustomerPortal
{
    public class Program
    {
         
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
//.ConfigureAppConfiguration((context, config) =>
//{
////var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//config.AddAzureKeyVault(
//keyVaultEndpoint,
//new DefaultAzureCredential());
//})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
