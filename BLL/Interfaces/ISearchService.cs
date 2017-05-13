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
        IEnumerable<TrackBLL> SearchForTrack(string category, string name);
        IEnumerable<AlbumBLL> SearchForAlbum(string category, string name);
        IEnumerable<AuthorBLL> SearchForAuthor(string category, string name);
        IEnumerable<GenreBLL> SearchForGenre(string category, string name);
    }
}
