using AutoMapper;
using Azure.Core;
using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;


namespace YouTube.Services
{
    public class UserService : IUserService
    {
        private readonly HttpContext httpContext;
        private readonly IMapper mapper;
        private readonly YouTubeDbContext context;
       
        public UserService(IHttpContextAccessor contextAccessor, IMapper mapper, YouTubeDbContext context)
        {
            httpContext = contextAccessor.HttpContext!;
            this.mapper = mapper;
            this.context = context;
        }

        //GET ALL
        public List<UserDto> GetUserDtos()
        {
            var users = context.Users.ToList();
            return mapper.Map<List<UserDto>>(users);
        }
        public List<User> GetUsers()
        {
            var users = context.Users.ToList();

            return users;
        }
        //GET
        public UserShortInfoDto GetShortUser(string userId)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == userId);

            return mapper.Map<UserShortInfoDto>(user);
        }
        public UserDto GetUserDto(string userId)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            return mapper.Map<UserDto>(user);
        }

        //ADD
        public void AddUser(UserDto model)
        {
            context.Users.Add(mapper.Map<User>(model));
            context.SaveChanges();
        }

        //REMOVE
        public void RemoveUser(int id)
        {
            var user = context.Users.Find(id);

            if (user == null) return;

            context.Users.Remove(user);
            context.SaveChanges();
        }
        
        //EDIT
        public void EditUser(UserDto model)
        {
            context.Users.Update(mapper.Map<User>(model));
            context.SaveChanges();
        }

    }
}
