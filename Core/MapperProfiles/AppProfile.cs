using AutoMapper;
using Core.Dtos;
using Data.Entities;

namespace YouTube.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<VideoDto, Video>().ReverseMap();
            CreateMap<UserDto, UserShortInfoDto>().ReverseMap();
            CreateMap<User, UserShortInfoDto>().ReverseMap();
            CreateMap<LikeDto, Like>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<SubscriberDto, Subscriber>().ReverseMap();
        }
    }
}
