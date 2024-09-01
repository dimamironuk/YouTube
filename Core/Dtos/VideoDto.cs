
using Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Core.Dtos
{
    public class VideoDto
    {
        public int? Id { get; set; } 
        public string UserId { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string VideoUrl { get; set; }
        public IFormFile? Video {  get; set; }
        public string PreviewUrl { get; set; }
        public IFormFile? Preview {  get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
