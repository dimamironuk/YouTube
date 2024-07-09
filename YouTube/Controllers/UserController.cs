using Microsoft.AspNetCore.Mvc;
using YouTube.Data;
using YouTube.Entities;
using YouTube.Models;

namespace YouTube.Controllers
{
    public class UserController : Controller
    {
        private YouTubeDbContext ctx = new YouTubeDbContext();

        public IActionResult Index()
        {
            var users = ctx.Users.ToList();


            return View(users);
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
