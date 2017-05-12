using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int? AuthorID { get; set; }
        public Author Author { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public Album()
        {
            Genres = new List<Genre>();
            Tracks = new List<Track>();
        }

    }
}
