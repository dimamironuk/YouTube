using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YouTube.Entities
{
    public class User
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Nickname is required")]
        public string Nickname { get; set; }

        //[Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is required")]
        //[StringLength(10, MinimumLength = 4, ErrorMessage = "Password must be between 4 and 10 characters long")]
        public string Password { get; set; }

        //[Url(ErrorMessage = "Invalid URL format")]
        public string? AvatarUrl { get; set; }

        //[Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        public ICollection<Video>? Videos { get; set; }
    }
}

