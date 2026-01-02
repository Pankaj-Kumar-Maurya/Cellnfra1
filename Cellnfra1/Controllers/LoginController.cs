using Cellnfra1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cellnfra1.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext _context;
        public LoginController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(string Email, string Password)
        {
            var user = _context.tbl_Accounts.FirstOrDefault(u => u.Email == Email && u.Password == Password);
            if (user != null && user.Role == "Editor" && user.IsActive == true)
            {
                HttpContext.Session.SetString("UserID", user.AccountID.ToString());
                HttpContext.Session.SetString("UserRole", user.Role);
                return RedirectToAction("CustomCMSPage", "PrivateCMS");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserRole");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
