using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;

namespace YouTube.Services
{
    public class CommentService : ICommentService
    {
        private readonly YouTubeDbContext context;
        private readonly IMapper mapper;

        public CommentService(YouTubeDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddComment(CommentDto model)
        {
            context.Comments.Add(mapper.Map<Comment>(model));
            context.SaveChanges();
        }

        public Comment GetComment(int idComment)
        {
            return context.Comments.Find(idComment);
        }

        public List<CommentDto> GetCommentDtos(int idVideo)
        {
            var comments = context.Comments.Where(c => c.IdVideo == idVideo);
            return mapper.Map<List<CommentDto>>(comments);
        }

        public void RemoveComment(int idComment)
        {
            context.Comments.Remove(GetComment(idComment));
            context.SaveChanges();
        }
    }
}
