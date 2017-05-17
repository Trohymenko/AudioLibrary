using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<TrackBLL> Search(string term, string category);
    }
}
