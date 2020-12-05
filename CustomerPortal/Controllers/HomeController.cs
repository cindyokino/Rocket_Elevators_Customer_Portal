using CustomerPortal.Areas.Identity.Data;
using CustomerPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace CustomerPortal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService = new ProductService();
        private readonly UserManager<CustomerPortalUser> _userManager; // Added/Injection UserManager to find the current logged user

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<CustomerPortalUser> userManager)
        {
            _logger = logger;
            _userManager = userManager; // code for UserManager from Areas\Identity\Pages\Account\Manage\ChangePassword.cshtml.cs
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Action to render the Intervention Form page
        public IActionResult Intervention(string elevatorSerialNumber, string columnId, string elevatorId, string buildingId, string batteryId)
        {
            var user_email = _userManager.GetUserName(User);
            var customer = _productService.getFullCustomerInfo(user_email);

            ViewBag.elevatorSerialNumber = elevatorSerialNumber;
            ViewBag.columnId = columnId;
            ViewBag.elevatorId = elevatorId;
            ViewBag.buildingId = buildingId;
            ViewBag.batteryId = batteryId;
            ViewBag.customer = customer;

            return View();
        }

        // Action to render the Update Customer Form page
        public IActionResult UpdateCustomer()
        {
            var user_email = _userManager.GetUserName(User);
            var customer = _productService.getFullCustomerInfo(user_email);

            ViewBag.customer = customer;

            return View();
        }

        // Action to render the Products page
        public IActionResult Products()
        {
            return View();
        }

        // ========== Function to get all the data from the customer that is logged at the portal using the email ========================================
        // /Home/getFullCustomerInfo
        public IActionResult getFullCustomerInfo()
        {
            var user_email = _userManager.GetUserName(User); 
            Console.WriteLine("email: " + user_email);

            var customer =  _productService.getFullCustomerInfo(user_email);

            Console.WriteLine("Called getFullCustomerInfo");

            _logger.LogInformation(" !!! CALLED FUNCTION getFullCustomerInfo !!! ");

            return View("~/Views/Home/Products.cshtml", customer);
        }
    }
}

