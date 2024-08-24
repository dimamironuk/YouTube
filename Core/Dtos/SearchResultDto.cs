using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class SearchResultDto
    {
        public object Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public object Result { get; set; }
        public string Type { get; set; } 
    }

}
