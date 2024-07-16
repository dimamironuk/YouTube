using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouTube.Data;
using YouTube.Dtos;
using YouTube.Entities;
using YouTube.Models;

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
