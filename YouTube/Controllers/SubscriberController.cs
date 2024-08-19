using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YouTube.Services;

namespace YouTube.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly ISubscriberService subscriberService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public SubscriberController(SubscriberService subscriberService)
        {
            this.subscriberService = subscriberService;
        }
        [HttpPost]
        public IActionResult AddSubscriber(string idAuthor)
        {
            var model = new SubscriberDto
            {
                IdSubscriber = UserId,
                IdAuthor = idAuthor.ToString()
            };
            subscriberService.AddSubscriber(model);
            return RedirectToAction("Index", "Video", new { id = idAuthor });
        }

        [HttpPost]
        public IActionResult RemoveSubscriber(string idAuthor)
        {
            var subscriber = subscriberService.GetSubscriber(UserId);
            if (subscriber != null && subscriber.IdAuthor == idAuthor.ToString())
            {
                subscriberService.RemoveSubscriber(idAuthor);
            }
            return RedirectToAction("Index", "Video", new { id = idAuthor });
        }
    }
}
