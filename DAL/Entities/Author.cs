using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public Author()
        {
            Albums = new List<Album>();
            Genres = new List<Genre>();
            Tracks = new List<Track>();
        }
    }
}
