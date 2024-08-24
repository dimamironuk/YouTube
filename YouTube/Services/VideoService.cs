using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;

namespace YouTube.Services
{
    public class VideoService : IVideoService
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
        public List<VideoDto> GetVideoDtos(string userId)
        {
            var videoDtos = mapper.Map<List<VideoDto>>(context.Videos.ToList());
            videoDtos.ForEach(video => video.Nickname = context.Users.FirstOrDefault(x => x.Id == userId).Nickname);
            return videoDtos;
        }
        public List<VideoDto> GetVideoDtos()
        {
            var videoDtos = mapper.Map<List<VideoDto>>(context.Videos.ToList());

            foreach (var videoDto in videoDtos)
            {
                var user = context.Users.FirstOrDefault(x => x.Id == videoDto.UserId);
                videoDto.Nickname = user?.Nickname ?? "Unknown";
            }

            return videoDtos;
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

        //EDIT
        public void EditVideo(VideoDto model)
        {
            context.Videos.Update(mapper.Map<Video>(model));
            context.SaveChanges();
        }

        public VideoDto GetVideoDto(int id)
        {
            return mapper.Map<VideoDto>(context.Videos.Find(id));
        }
    }
}
