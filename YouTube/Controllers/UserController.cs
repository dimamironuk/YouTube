using Microsoft.AspNetCore.Mvc;
using Core.Dtos;
using Newtonsoft.Json;
using YouTube.Services;
using System.Security.Claims;
using Core.Interfaces;

namespace YouTube.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IVideoService videoService;
        private readonly ISubscriberService subscriberService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        public UserController(IUserService userService, IVideoService videoService, ISubscriberService subscriberService)
        {
            this.userService = userService;
            this.videoService = videoService;
            this.subscriberService = subscriberService;
        }

        public IActionResult Index()
        {
            var user = userService.GetUserDto(UserId);

            var videos = user != null ? videoService.GetVideoDtos(UserId).Where(x => x.UserId == user.Id) : null;
            ViewBag.Videos = videos;
            ViewBag.CountSubscriber = subscriberService.CountSubscriber(UserId);

            return user == null ? RedirectToAction("SignIn") : View(user);
        }

        public IActionResult Subscriptions()
        {
            var allUsers = userService.GetUserDtos();

            var subscribedUserIds = subscriberService.GetSubscriptions(UserId).Select(s => s.IdAuthor).ToList();

            var subscribedUsers = allUsers.Where(user => subscribedUserIds.Contains(user.Id)).ToList();

            return View(subscribedUsers);
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
