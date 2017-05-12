using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TrackDTO
    {
        public int TrackID { get; set; }
        public string TrackName { get; set; }
        public string TrackAddress { get; set; }
        public int? AuthorID { get; set; }
    }
}
