using Microsoft.AspNetCore.Mvc;
using Core.Dtos;
using Newtonsoft.Json;
using YouTube.Services;
using System.Security.Claims;

namespace YouTube.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly VideoService videoService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        public UserController(UserService userService, VideoService videoService)
        {
            this.userService = userService;
            this.videoService = videoService;
        }

        public IActionResult Index()
        {
            var user = userService.GetUserDto(UserId);

            var videos = user != null ? videoService.GetVideoDtos(UserId).Where(x => x.UserId == user.Id) : null;
            ViewBag.Videos = videos;

            return user == null ? RedirectToAction("SignIn") : View(user);
        }

        public IActionResult Subscriptions()
        {
            return View(userService.GetUserDtos());
        }
        [HttpGet]


        [HttpGet]
        public IActionResult Edit(string id)
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
