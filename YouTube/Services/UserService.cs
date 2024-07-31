using AutoMapper;
using Azure.Core;
using Core.Dtos;
using Data.Data;
using Data.Entities;
using Newtonsoft.Json;
using System.Net;


namespace YouTube.Services
{
    public class UserService
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
        public UserShortInfoDto GetShortUser()
        {

            var ids = httpContext.Request.Cookies["UserId"];
            var id = JsonConvert.DeserializeObject<List<int>>(ids ?? "[]");
            var user = id.Count != 0 ? context.Users.FirstOrDefault(x => x.Id == id.First()) : null;

            return user != null ? mapper.Map<UserShortInfoDto>(user) : null;
        }
        public UserDto GetUserDto(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            return user != null ? mapper.Map<UserDto>(user) : null;
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
