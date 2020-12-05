using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CustomerPortal.Models
{
    public class ProductService 
    {
        private readonly ILogger<ProductService> _logger;


        private readonly HttpClient _httpClient = new HttpClient();

        public ProductService()
        {
            var serviceProvider = new ServiceCollection()
                      .AddLogging() //<-- You were missing this
                      .BuildServiceProvider();
            _logger = serviceProvider.GetService<ILoggerFactory>()
                        .CreateLogger<ProductService>();
        }

        // // ========== Function that calls endpoint /api/Customers/id to get all the data from the customer that is logged at the portal ============
        public Customer getFullCustomerInfo(string email)
        {
            var result = _httpClient.GetAsync("https://rocketelevatorsrestapicindy.azurewebsites.net/api/Customers/" + email).Result;
            var contentBody = result.Content.ReadAsStringAsync().Result;

            Customer customer = JsonConvert.DeserializeObject<Customer>(contentBody);

            _logger.LogInformation("customer email: {}", customer.cpy_contact_email);
            _logger.LogInformation("customer buildings: {}", customer.buildings);
            Console.WriteLine(" ============ all the CUSTOMER infos are here!!! ============ ");
            Console.WriteLine(customer.buildings.Count);

            return customer;
        }

        //------------------------------ TEST ------------------------------
        public void helloWorld() //Test
        {
            _logger.LogInformation("Hello World!!!");
            Console.WriteLine("Hello again");
        }
        //------------------------------------------------------------------
    }
}

