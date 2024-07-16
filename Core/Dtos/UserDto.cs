namespace Core.Dtos
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime Birthday { get; set; }
    }
}
