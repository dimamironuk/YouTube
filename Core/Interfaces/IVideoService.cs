using Core.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IVideoService
    {
        public List<Video> GetVideos();
        public List<VideoDto> GetVideoDtos(string userId);
        public List<VideoDto> GetVideoDtos();
        public VideoDto GetVideoDto(int id);
        public Video GetVideo(int id);
        public void AddVideo(VideoDto model);
        public void RemuveVideo(int id);
        public void EditVideo(VideoDto model);
    }
}
