using Core.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubscriberService
    {
        public IEnumerable<Subscriber> GetSubscriptions(string userId);
        public List<SubscriberDto> GetMySubscribers(string idAuthor);
        public int CountSubscriber(string idUser);
        public Subscriber GetSubscriber(string idUser);
        public void AddSubscriber(SubscriberDto model);
        public void RemoveSubscriber(string idAuthor);
        public bool IsSubscribed(string userId, string authorId);

    }
}
