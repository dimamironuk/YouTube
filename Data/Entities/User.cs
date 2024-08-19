using Microsoft.AspNetCore.Identity;

namespace Data.Entities
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Video>? Videos { get; set; }
        public ICollection<Subscriber>? Subscribers { get; set; }

    }
}

