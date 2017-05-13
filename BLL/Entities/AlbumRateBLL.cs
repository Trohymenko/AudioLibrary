using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class AlbumRateBLL
    {
        public int AlbumRateId { get; set; }
        public int AlbumRateValue { get; set; }
        public string UserName { get; set; }
        public int? AlbumId { get; set; }
    }
}
