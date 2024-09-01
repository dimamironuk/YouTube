using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class UserDto
    {
        public string? Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public IFormFile? Avatar {  get; set; }
        public DateTime Birthday { get; set; }
    }
}
