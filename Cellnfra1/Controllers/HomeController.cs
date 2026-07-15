using Cellnfra1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Cellnfra1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;
        private readonly EmailSettings _emailSettings;


        public HomeController(ILogger<HomeController> logger, DatabaseContext context, IOptions<EmailSettings> emailSettings)
        {
            _logger = logger;
            _context = context;
            _emailSettings = emailSettings.Value;
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

        [HttpPost]
        public async Task<IActionResult> Contact(string inputName, string inputPhone, string inputEmail, string inputService, string inputMessage)
        {
            try
            {
                using var mail = new MailMessage();

                mail.From = new MailAddress(
                    _emailSettings.FromEmail,
                    _emailSettings.FromName);

                mail.ReplyToList.Add(new MailAddress(inputEmail));

                mail.To.Add(_emailSettings.MailTo);

                mail.Subject = $"New Contact Form Submission : {inputService}";

                mail.Body = $"Name: {inputName}\n" +
                            $"Email: {inputEmail}\n" +
                            $"Phone: {inputPhone}\n" +
                            $"Service: {inputService}\n\n" +
                            $"Message:\n{inputMessage}";

                using var smtp = new SmtpClient(
                    _emailSettings.Host,
                    _emailSettings.Port);

                smtp.Credentials = new NetworkCredential(
                    _emailSettings.Username,
                    _emailSettings.Password);

                await smtp.SendMailAsync(mail);
                TempData["Success"] = "Thank you! Your message has been sent successfully.";
                return RedirectToAction("Contact");
            }
            catch
            {
                TempData["Error"] = "Sorry! Unable to send your message. Please try again.";

                return RedirectToAction("Contact");
            }
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

        public class EmailSettings
        {
            public required string Host { get; set; }
            public required int Port { get; set; }
            public required string Username { get; set; }
            public required string Password { get; set; }
            public required string FromEmail { get; set; }
            public required string FromName { get; set; }
            public required string MailTo { get; set; }
        }
    }
}
