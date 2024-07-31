using AutoMapper;
using Core.Dtos;
using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace YouTube.Services
{
    public class VideoService
    {
        private readonly YouTubeDbContext context;
        private readonly IMapper mapper;

        public VideoService(YouTubeDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // GET ALL
        public List<Video> GetVideos()
        {
            return context.Videos.ToList();
        }
        public List<VideoDto> GetVideoDtos()
        {
            return mapper.Map<List<VideoDto>>(context.Videos.ToList());
        }

        //GET
        public Video GetVideo(int id)
        {
            return context.Videos.Find(id);
        }

        // ADD 
        public void AddVideo(VideoDto model)
        {
            context.Videos.Add(mapper.Map<Video>(model));
            context.SaveChanges();
        }

        // REMOVE    
        public void RemuveVideo(int id)
        {
            context.Videos.Remove(GetVideo(id));
            context.SaveChanges();
        }
    }
}
