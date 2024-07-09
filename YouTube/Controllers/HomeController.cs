using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YouTube.Data;
using YouTube.Entities;
using YouTube.Models;

namespace YouTube.Controllers
{
    public class HomeController : Controller
    {
        private YouTubeDbContext ctx = new YouTubeDbContext();
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            var users = ctx.Users.ToList();
            return View(users);
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
