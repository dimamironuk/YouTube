using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Core.Dtos;
using Data.Entities;
using YouTube.Services;
using System.Security.Claims;

namespace YouTube.Controllers
{
    public class VideoController : Controller
    {
        private readonly VideoService videoService;
        private readonly UserService userService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public VideoController(VideoService videoService, UserService userService)
        {
            this.videoService = videoService;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View(videoService.GetVideoDtos(UserId));
        }
        [HttpGet]
        public IActionResult AddVideo(string id)
        {
            var user = userService.GetUserDto(id);
            var videos = videoService.GetVideoDtos(UserId);

            var model = new VideoDto
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!,
                UserNickname = user.Nickname,
                DateOfPublication = DateTime.Now
            };

            ViewBag.CreateMode = true;
            ViewBag.User = user;
            ViewData["Videos"] = videos;

            return View("Upsert");
        }

        [HttpPost]
        public IActionResult AddVideo(VideoDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = true;
                return View("Upsert", model);
            }
            model.Id = null;
            videoService.AddVideo(model);
            return RedirectToAction("Index", "User");
        }
        public IActionResult Delete(int id)
        {
            videoService.RemuveVideo(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var video = videoService.GetVideoDtos(UserId).FirstOrDefault(v => v.Id == id);

            if (video == null) return NotFound();

            ViewBag.CreateMode = false;
            ViewBag.User = userService.GetUserDto(video.UserId);

            return View("Upsert", video);
        }

        [HttpPost]
        public IActionResult Edit(VideoDto model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateMode = false;
                return View("Upsert", model);
            }

            videoService.EditVideo(model);

            return RedirectToAction("Index");
        }
    }
    }
