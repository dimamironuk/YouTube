using Core.Dtos;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YouTube.Services;

namespace YouTube.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public CommentController(ICommentService commentService)
        { 
            this.commentService = commentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(string CommentText, int VideoId)
        {
            CommentText = CommentText?.Trim();
            CommentText = CommentText?.Trim();
            CommentText = CommentText?.Trim();
            CommentText = CommentText?.Trim();

            if (string.IsNullOrEmpty(CommentText))
            {
                TempData["ErrorMessage"] = "Comment cannot be empty.";
                return RedirectToAction("Revision", "Video", new { idVideo = VideoId });
            }

            var model = new CommentDto()
            {
                IdCommentator = UserId,
                IdVideo = VideoId,
                TextComment = CommentText,
                DateOfPublication = DateTime.Now
            };

            commentService.AddComment(model);
            return RedirectToAction("Revision", "Video", new { idVideo = VideoId });
        }


        [HttpPost]
        public IActionResult Delete(int idComment)
        {
            commentService.RemoveComment(idComment);
            return RedirectToAction("Index", "Video");
        }
    }
}
