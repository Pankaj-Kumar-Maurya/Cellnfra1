using Cellnfra1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cellnfra1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WhyUs()
        {
            return View();
        }
        public IActionResult ElectronicsRepairs()
        {
            return View();
        }
        public IActionResult ElectronicRefurbish()
        {
            return View();
        }
        public IActionResult AssemblyTest()
        {
            return View();
        }
        public IActionResult ElectronicPartsSales()
        {
            return View();
        }
        public IActionResult ReverseLogistics()
        {
            return View();
        }
        public IActionResult BespokeSolutions()
        {
            return View();
        }


        public IActionResult Telecom()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult EWasteManagement()
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
    }
}
