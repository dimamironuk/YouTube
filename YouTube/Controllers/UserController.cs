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
        [HttpGet]
        public IActionResult SignUp()
        {
            var users = ctx.Users.ToList();
            ViewData["Users"] = users;
            ViewBag.CreateMode = true;
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                return View("Upsert", model);
            }

            ctx.Users.Add(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult SignIn()
        {
            var users = ctx.Users.ToList();
            return View(users);
        }
        /*[HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            var user = ctx.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());

                return RedirectToAction("Profile", new { id = user.Id });
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password";
                return View();
            }
        }*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = ctx.Users.Find(id);

            if (user == null) return NotFound();

            ViewBag.CreateMode = false;
            return View("Upsert", user);
        }
        [HttpPost]
        public IActionResult Edit(User model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                return View("Upsert", model);
            }

            ctx.Users.Update(model);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = ctx.Users.Find(id);

            if (user == null) return NotFound();

            ctx.Users.Remove(user);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
