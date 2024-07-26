using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Core.Dtos;
using Data.Entities;

namespace YouTube.Controllers
{
    public class VideoController : Controller
    {
        private YouTubeDbContext ctx = new YouTubeDbContext();
        private readonly IMapper mapper;
        public VideoController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var videos = ctx.Videos.Include(x => x.User).ToList();

            return View(mapper.Map<List<VideoDto>>(videos));
        }
        [HttpGet]
        public IActionResult AddVideo()
        {
            var videos = ctx.Users.ToList();
            ViewData["Videos"] = mapper.Map<List<VideoDto>>(videos);
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

            ctx.Videos.Add(mapper.Map<Video>(model));
            ctx.SaveChanges();

            return RedirectToAction("Index","User");
        }
        public IActionResult Delete(int id)
        {
            var video = ctx.Videos.Find(id);

            if (video == null) return NotFound();

            ctx.Videos.Remove(mapper.Map<Video>(video));
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
