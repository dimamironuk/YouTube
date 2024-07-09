namespace YouTube.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

    }
}
