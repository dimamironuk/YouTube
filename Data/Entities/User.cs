
namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Video>? Videos { get; set; }
    }
}

