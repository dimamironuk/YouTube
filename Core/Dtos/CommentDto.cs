using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CommentDto
    {
        public int? Id { get; set; }
        public string IdCommentator { get; set; }
        public User Commentator { get; set; }
        public int IdVideo { get; set; }
        public string TextComment { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
