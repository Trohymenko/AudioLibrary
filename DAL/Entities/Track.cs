using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Track
    {
        public int TrackID { get; set; }
        public string TrackName { get; set; }
        public string TrackLocation { get; set; }
        public int? AuthorID { get; set;}
        public virtual Author Author { get; set; }
        public int? AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<TrackRate> TrackRates { get; set; }
        public Track()
        {
            Genres = new List<Genre>();
            TrackRates = new List<TrackRate>();
        }

    }
}
