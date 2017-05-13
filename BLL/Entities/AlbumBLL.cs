using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class AlbumBLL
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? AuthorID { get; set; }
    }
}
