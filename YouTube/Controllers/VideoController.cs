using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YouTube.Data;
using YouTube.Entities;
using YouTube.Models;

namespace YouTube.Controllers
{
    public class VideoController : Controller
    {
        private YouTubeDbContext ctx = new YouTubeDbContext();
        public IActionResult Index()
        {
            var videos = ctx.Videos.Include(x => x.User).ToList();

            return View(videos);
        }
        public IActionResult Delete(int id)
        {
            var video = ctx.Videos.Find(id);

            if (video == null) return NotFound();

            ctx.Videos.Remove(video);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
