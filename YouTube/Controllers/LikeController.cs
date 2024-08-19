using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace YouTube.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeService likeService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }
        [HttpPost]
        public IActionResult AddOrRemoveLike(int idVideo)
        {
            var model = new LikeDto()
            {
                IdUser = UserId,
                VideoId = idVideo
            };
            likeService.AddOrRemoveLike(model);
            return RedirectToAction("Revision", "Video", new { idVideo = idVideo });
        }
    }
}
