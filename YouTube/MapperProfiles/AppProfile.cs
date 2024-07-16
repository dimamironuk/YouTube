using AutoMapper;
using YouTube.Dtos;
using YouTube.Entities;

namespace YouTube.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<VideoDto, Video>().ReverseMap();
        }
    }
}
