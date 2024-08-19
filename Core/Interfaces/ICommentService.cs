using Core.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICommentService
    {
        public List<CommentDto> GetCommentDtos(int idVideo);
        public Comment GetComment(int idComment);
        public void AddComment (CommentDto model);
        public void RemoveComment (int idComment);
    }
}
