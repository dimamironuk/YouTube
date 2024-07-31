
namespace Core.Dtos
{
    public class VideoDto
    {
        public int? Id { get; set; } 
        public int UserId { get; set; }
        public string UserNickname { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string VideoUrl { get; set; }
        public string PreviewUrl { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
