﻿namespace Data.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string VideoUrl { get; set; }
        public string PreviewUrl { get; set; }
        public DateTime DateOfPublication { get; set; }

        public ICollection<Like>? Likes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
