using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace YouTube.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly YouTubeDbContext context;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;

        public SubscriberService(YouTubeDbContext context, IMapper mapper, IEmailSender emailSender)
        {
            this.context = context;
            this.mapper = mapper;
            this.emailSender = emailSender;
        }

        public int CountSubscriber(string idUser)
        {
            int count = context.Subscribers.Where(s => s.IdAuthor == idUser).Count();
            return count;
        }

        public async Task AddSubscriber(SubscriberDto model, string email)
        {
            context.Subscribers.Add(mapper.Map<Subscriber>(model));
            context.SaveChanges();
            var count = GetMySubscribers(model.IdAuthor).Count;
            if (GetMySubscribers(model.IdAuthor).Count == 2)
            {
                await emailSender.SendEmailAsync(email, $"Congratulations, you now have {GetMySubscribers(model.IdAuthor).Count} subscribers", "<h1>You guys keep it up</h1>");
            }
        }

        public void RemoveSubscriber(string idAuthor)
        {
            context.Subscribers.Remove(GetSubscriber(idAuthor));
            context.SaveChanges();
        }
        public IEnumerable<Subscriber> GetSubscriptions(string userId)
        {
            return context.Subscribers.Where(s => s.IdSubscriber == userId).ToList();
        }
        public Subscriber GetSubscriber(string idUser)
        {
            return context.Subscribers.FirstOrDefault(s => s.IdSubscriber == idUser);
        }
        public bool IsSubscribed(string userId, string authorId)
        {
            return context.Subscribers.Any(s => s.IdSubscriber == userId && s.IdAuthor == authorId);
        }

        public List<SubscriberDto> GetMySubscribers(string idAuthor)
        {
            return mapper.Map<List<SubscriberDto>>(context.Subscribers.Where(s => s.IdAuthor == idAuthor));
        }
    }
}
