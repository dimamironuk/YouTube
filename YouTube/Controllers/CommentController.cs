using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YouTube.Services;

namespace YouTube.Controllers
{
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
        public IActionResult AddComment(CommentDto model)
        {
            model.IdCommentator = UserId;
            commentService.AddComment(model);
            return RedirectToAction("Index", "Video", new { id = model.IdVideo });
        }

        [HttpPost]
        public IActionResult Delete(int idComment)
        {
            commentService.RemoveComment(idComment);
            return RedirectToAction("Index", "Video");
        }
    }
}
