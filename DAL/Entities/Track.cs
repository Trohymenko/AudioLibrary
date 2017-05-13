using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Track
    {
        public int TrackID { get; set; }
        public string TrackName { get; set; }
        public string TrackAddress { get; set; }
        public int? AuthorID { get; set;}
        public Author Author { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<TrackRate> TrackRates { get; set; }
        public Track()
        {
            Albums = new List<Album>();
            Genres = new List<Genre>();
        }

    }
}
