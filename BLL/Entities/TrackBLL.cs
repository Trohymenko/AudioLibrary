﻿using System;
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
        public string TrackAddress { get; set; }
        public int? AuthorID { get; set; }
        public string AuthorName { get; set; }
        public int TrackRateAverage { get; set; }
    }
}
