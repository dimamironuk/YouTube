using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class LikeDto
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public int VideoId { get; set; }
    }
}
