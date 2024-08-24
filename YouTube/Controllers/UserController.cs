using Microsoft.AspNetCore.Mvc;
using Core.Dtos;
using Newtonsoft.Json;
using YouTube.Services;
using System.Security.Claims;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace YouTube.Controllers
{
    [Authorize]
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

        [HttpGet("User/Index")]
        public IActionResult Index()
        {
            var user = userService.GetUserDto(UserId);
            if (user == null)
            {
                return RedirectToAction("SignIn", "Account");
            }

            var videos = videoService.GetVideoDtos(UserId).Where(x => x.UserId == user.Id);
            ViewBag.Videos = videos;
            ViewBag.CountSubscriber = subscriberService.CountSubscriber(UserId);

            return View(user);
        }

        [HttpGet("User/Index/{id}")]
        public IActionResult Index(string id)
        {
            var user = userService.GetUserDto(id);

            var videos = videoService.GetVideoDtos(id).Where(x => x.UserId == user.Id);
            ViewBag.Videos = videos;
            ViewBag.CountSubscriber = subscriberService.CountSubscriber(id);

            return View(user);
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
