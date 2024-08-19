using Core.Dtos;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YouTube.Services;

namespace YouTube.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly ISubscriberService subscriberService;
        private readonly IVideoService videoService;
        private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public SubscriberController(ISubscriberService subscriberService, IVideoService videoService)
        {
            this.subscriberService = subscriberService;
            this.videoService = videoService;
        }
        [HttpPost]
        public IActionResult ToggleSubscription(string idUser, int idVideo)
        {
            var subscriber = subscriberService.GetSubscriber(idUser);
            if(idUser != videoService.GetVideo(idVideo).UserId)
            {
                if (subscriber != null)
                {
                    subscriberService.RemoveSubscriber(subscriber.IdSubscriber);
                }
                else
                {
                    var model = new SubscriberDto
                    {
                        IdSubscriber = UserId,
                        IdAuthor = videoService.GetVideo(idVideo).UserId
                    };
                    subscriberService.AddSubscriber(model);
            }
            }

            return RedirectToAction("Revision", "Video", new { idVideo = idVideo });
        }
    }
}
