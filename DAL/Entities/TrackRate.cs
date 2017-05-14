using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class TrackRate
    {
        public int TrackRateId { get; set; }
        public double TrackRateValue { get; set; }
        public string UserName { get; set; }
        public int? TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}
