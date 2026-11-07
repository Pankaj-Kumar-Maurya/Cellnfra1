using Microsoft.AspNetCore.Mvc;

namespace Cellnfra1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
