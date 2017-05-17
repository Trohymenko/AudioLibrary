using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TrackBLL
    {
        public int TrackID { get; set; }
        public string TrackName { get; set; }
        public string TrackLocation { get; set; }
        public int? AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AlbumName { get; set; }
        public string GenreName { get; set; }
        public double TrackRateAverage { get; set; }
    }
}
