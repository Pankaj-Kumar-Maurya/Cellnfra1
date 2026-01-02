using Cellnfra1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cellnfra1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var HomePageContent = _context.tbl_PostContents.Where(x => x.Slug == "Home").ToList();
            return View(HomePageContent);
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
        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Brands()
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
        public IActionResult CPEDataNetworks()
        {
            return View();
        }
        public IActionResult IndustrialElectronics()
        {
            return View();
        }
        public IActionResult OpticalNetworks()
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
