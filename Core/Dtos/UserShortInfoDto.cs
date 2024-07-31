using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserShortInfoDto
    {
        public int? Id { get; set; }
        public string Nickname { get; set; }
        public string AvatarUrl { get; set; }
    }
}
