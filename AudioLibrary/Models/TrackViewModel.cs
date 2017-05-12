using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudioLibrary.Models
{
    public class TrackViewModel
    {
        public int TrackID { get; set; }
        public string TrackName { get; set; }
        public string TrackAddress { get; set; }
        public int? AuthorID { get; set; }
        public string AuthorName { get; set; }
    }
}