using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class AlbumRate
    {
        public int AlbumRateId { get; set; }
        public int AlbumRateValue { get; set; }
        public string UserName { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
