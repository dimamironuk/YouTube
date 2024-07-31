using Microsoft.AspNetCore.Mvc;
using Core.Dtos;
using Newtonsoft.Json;
using YouTube.Services;

namespace YouTube.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly VideoService videoService;
        public UserController(UserService userService, VideoService videoService)
        {
            this.userService = userService;
            this.videoService = videoService;
        }

        public IActionResult Index()
        {
            var idCookie = Request.Cookies["UserId"];
            var id = JsonConvert.DeserializeObject<List<int>>(idCookie ?? "[]");

            var user = userService.GetUserDto(id.Count != 0 ? id.First() : -1);

            var videos = user != null ? videoService.GetVideoDtos().Where(x => x.UserId == user.Id) : null;
            ViewBag.Videos = videos;

            return user == null ? RedirectToAction("SignIn") : View(user);
        }
        public IActionResult Exit()
        {
            Response.Cookies.Delete("UserId");

            return RedirectToAction("Index", "Video");
        }
        public IActionResult Subscriptions()
        {
            return View(userService.GetUserDtos());
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            var users = userService.GetUserDtos();
            ViewData["Users"] = users;
            ViewBag.CreateMode = true;
            return View("Upsert");
        }

        [HttpPost]
        public IActionResult SignUp(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                return View("Upsert", model);
            }

            userService.AddUser(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var users = userService.GetUserDtos();
            return View(users);
        }

        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            var user = userService.GetUsers().FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                var userIdList = new List<int> { user.Id };
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(10),
                    HttpOnly = true,
                    IsEssential = true
                };

                Response.Cookies.Append("UserId", JsonConvert.SerializeObject(userIdList), cookieOptions);
                return RedirectToAction("Index");
            }
            else
            {
                var users = userService.GetUserDtos();
                return View(users);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = userService.GetUserDtos().FirstOrDefault(u => u.Id == id);

            if (user == null) return NotFound();

            ViewBag.CreateMode = false;
            return View("Upsert", user);
        }

        [HttpPost]
        public IActionResult Edit(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                return View("Upsert", model);
            }

            userService.EditUser(model);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            userService.RemoveUser(id);

            return RedirectToAction("Index");
        }
    }
}
