namespace YouTube.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nicname { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime Birthday { get; set; }
    }
}
