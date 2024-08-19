using Core.Dtos;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ILikeService
    {
        void AddOrRemoveLike(LikeDto model);
        int CountLikes(int idVideo);
    }
}
