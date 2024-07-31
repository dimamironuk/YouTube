using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Core.Dtos;
using Data.Entities;
using YouTube.Services;

namespace YouTube.Controllers
{
    public class VideoController : Controller
    {
        private readonly VideoService videoService;

        public VideoController(VideoService videoService)
        {
            this.videoService = videoService;
        }
        public IActionResult Index()
        {
            return View(videoService.GetVideoDtos());
        }
        [HttpGet]
        public IActionResult AddVideo()
        {
            ViewData["Videos"] = videoService.GetVideoDtos();
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

            videoService.AddVideo(model);
            return RedirectToAction("Index","User");
        }
        public IActionResult Delete(int id)
        {
            videoService.RemuveVideo(id);
            return RedirectToAction("Index");
        }
    }
}
