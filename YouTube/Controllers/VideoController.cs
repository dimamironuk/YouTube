using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Core.Dtos;
using Data.Entities;
using YouTube.Services;
using System.Security.Claims;
using Core.Interfaces;

namespace YouTube.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService videoService;
        private readonly IUserService userService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public VideoController(IVideoService videoService, IUserService userService)
        {
            this.videoService = videoService;
            this.userService = userService;
        }
        public IActionResult Revision(int idVideo)
        {
            var video = videoService.GetVideoDto(idVideo);
            ViewData["Video"] = video;
            ViewData["User"] = userService.GetUserDto(UserId) ;
            return View(video);
        }
        public IActionResult Index()
        {
            return View(videoService.GetVideoDtos());
        }
        [HttpGet]
        public IActionResult AddVideo(string idUser)
        {
            var user = userService.GetUserDto(idUser);
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

            return View("Upsert", model);
        }

        [HttpPost]
        public IActionResult AddVideo(VideoDto model)
        {

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
