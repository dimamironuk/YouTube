using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using System.Linq;

namespace YouTube.Services
{
    public class LikeService : ILikeService
    {
        private readonly YouTubeDbContext context;
        private readonly IMapper mapper;

        public LikeService(YouTubeDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddOrRemoveLike(LikeDto model)
        {
            var existingLike = context.Likes
                .FirstOrDefault(l => l.VideoId == model.VideoId && l.IdUser == model.IdUser);

            if (existingLike != null)
            {
                context.Likes.Remove(existingLike);
            }
            else
            {
                context.Likes.Add(mapper.Map<Like>(model));
            }

            context.SaveChanges();
        }

        public int CountLikes(int idVideo)
        {
            return context.Likes.Count(l => l.VideoId == idVideo);
        }
    }
}
