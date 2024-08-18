using AutoMapper;
using Core.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserService
    {
        public List<UserDto> GetUserDtos();
        public List<User> GetUsers();
        public UserShortInfoDto GetShortUser(string userId);
        public UserDto GetUserDto(string userId);
        public void AddUser(UserDto model);
        public void RemoveUser(int id);
        public void EditUser(UserDto model);
    }
}
