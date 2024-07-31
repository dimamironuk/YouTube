namespace Data.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string VideoUrl { get; set; }
        public string PreviewUrl { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
