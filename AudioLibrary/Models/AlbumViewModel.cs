using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AudioLibrary.Models
{
    public class AlbumViewModel
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? AuthorID { get; set; }
    }
}