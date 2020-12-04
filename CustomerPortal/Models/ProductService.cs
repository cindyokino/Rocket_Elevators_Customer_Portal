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

            var serializerSettings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects };

            Customer customer = JsonConvert.DeserializeObject<Customer>(contentBody);

            customer.buildings.ForEach(building => 
            {
                building.customer = customer;
                building.batteries.ForEach(battery =>
                {
                    battery.Building = building;
                    battery.columns.ForEach(column =>
                    {
                        column.Battery = battery;
                        column.elevators.ForEach(elevator => {
                            elevator.Column = column;
                        });
                    });
                });
            });

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

//// CREATE FUNCTIONS:
//// Method to GET customer infos from Rocket Elevators Database using the REST API
//// Method to Sign Up - verify if email exists at Database
//public async System.Threading.Tasks.Task<IActionResult> verifyEmailApiAsync()
//{
//    using var client = new HttpClient();

//    var result = await client.GetAsync("https://rocketelevatorsrestapicindy.azurewebsites.net/api/Interventions");
//    //Console.WriteLine(result.StatusCode);

//    var contentBody = await result.Content.ReadAsStringAsync();

//    List<InterventionDto> interventions = JsonConvert.DeserializeObject<List<InterventionDto>>(contentBody);

//    _logger.LogInformation("Author: {}", interventions[0].Author);
//    //Console.Write("Hello WORLD!!");
//    //Debug.WriteLine("Test");

//    return new EmptyResult();
//}

//// ========== Function that calls endpoint /api/Customers/get-customer-id to get the customer_id using the customer's email ====================
//public async System.Threading.Tasks.Task<int> getCustomerIdUsingEmail(string email)
////public int getCustomerIdUsingEmail(string email)
//{
//    HttpResponseMessage result = await _httpClient.GetAsync("https://rocketelevatorsrestapicindy.azurewebsites.net/api/Customers/get-id-" + email);
//    var contentBody = await result.Content.ReadAsStringAsync();
//    var user_id = JsonConvert.DeserializeObject(contentBody);

//    Console.WriteLine(" ============ !!! YOU FOUND THE USER ID !!! ============ ");
//    Console.WriteLine(user_id);

//    return (int)user_id; //VERIFY HOW TO RETURN A INT !!! TODO_CINDY
//}

