using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public Genre()
        {
            Albums = new List<Album>();
            Authors = new List<Author>();
            Tracks = new List<Track>();
        }
    }
}
