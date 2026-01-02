using Cellnfra1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace Cellnfra1.Controllers
{
    public class PrivateCMSController : Controller
    {
        private readonly DatabaseContext _context;
        public PrivateCMSController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CustomCMSPage()
        {            
            if(HttpContext.Session.GetString("UserID") == null || HttpContext.Session.GetString("UserRole") != "Editor")
            {
                return RedirectToAction("Index", "Home");
            }
            return View(_context.tbl_PostContents.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(tbl_PostContent post)
        {
            post.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {

                _context.tbl_PostContents.Add(post);
                _context.SaveChanges();
                return RedirectToAction("CustomCMSPage");
            }
            return View(post);
        }


        public IActionResult Edit(int id)
        {
            var post = _context.tbl_PostContents.FirstOrDefault(x => x.Id == id);
            if (post == null)
                return NotFound();

            return View("Update", post);
        }

        [HttpPost]
        public IActionResult Update(tbl_PostContent post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            var existing = _context.tbl_PostContents.FirstOrDefault(x => x.Id == post.Id);
            if (existing == null)
                return NotFound();

            existing.Slug = post.Slug;
            existing.DivSlug = post.DivSlug;
            existing.Content = post.Content;
            existing.CreatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("CustomCMSPage");
        }

        //public IActionResult Details(int id)
        //{
        //    var post = _context.tbl_PostContents.Find(id);
        //    return View(post);
        //}
        public IActionResult Delete(int id)
        {
            var post = _context.tbl_PostContents.FirstOrDefault(x => x.Id == id);

            if (post == null)
                return NotFound();

            // 1. Find all image src paths inside HTML
            var imgRegex = new Regex("<img[^>]+src=\"(?<url>[^\"]+)\"", RegexOptions.IgnoreCase);
            var matches = imgRegex.Matches(post.Content);

            foreach (Match match in matches)
            {
                var imageUrl = match.Groups["url"].Value;

                // Only delete local uploaded images
                if (imageUrl.StartsWith("/uploads/"))
                {
                    var imagePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        imageUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString())
                    );

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
            }

            // 2. Remove post from database
            _context.tbl_PostContents.Remove(post);
            _context.SaveChanges();

            return RedirectToAction("CustomCMSPage");
        }

    }
}
