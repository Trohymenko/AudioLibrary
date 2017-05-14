using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TrackRateBLL
    {
        public int TrackRateID { get; set; }
        public int TrackRateValue { get; set; }
        public string UserName { get; set; }
        public int? TrackId { get; set; }
    }
}
