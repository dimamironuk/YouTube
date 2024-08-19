using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace YouTube.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly YouTubeDbContext context;
        private readonly IMapper mapper;

        public SubscriberService(YouTubeDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public int CountSubscriber(string idUser)
        {
            int count = context.Subscribers.Where(s => s.IdAuthor == idUser).Count();
            return count;
        }

        public void AddSubscriber(SubscriberDto model)
        {
            context.Subscribers.Add(mapper.Map<Subscriber>(model));
            context.SaveChanges();
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
