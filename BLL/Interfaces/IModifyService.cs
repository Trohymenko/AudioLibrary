using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IModifyService
    {
        void CreateTrack(TrackBLL trackBLL, AuthorBLL authorBLL,IEnumerable<GenreBLL> genresBLL, IEnumerable<AlbumBLL> albumsBLL);
        void CreateGenre(GenreBLL genreBLL, IEnumerable<TrackBLL> tracksBLL, IEnumerable<AlbumBLL> albumsBLL, IEnumerable<AuthorBLL> authorsBLL);
        void CreateAuthor(AuthorBLL authorBLL, IEnumerable<GenreBLL> genresBLL, IEnumerable<AlbumBLL> albumsBLL, IEnumerable<TrackBLL> tracksBLL);
        void CreateAlbum(AlbumBLL albumBLL, AuthorBLL authorBLL, IEnumerable<GenreBLL> genresBLL, IEnumerable<TrackBLL> tracksBLL);

        void UpdateTrack(TrackBLL trackBLL, AuthorBLL authorBLL, IEnumerable<GenreBLL> genresBLL, IEnumerable<AlbumBLL> albumsBLL);
        void UpdateGenre(GenreBLL genreBLL, IEnumerable<TrackBLL> tracksBLL, IEnumerable<AlbumBLL> albumsBLL, IEnumerable<AuthorBLL> authorsBLL);
        void UpdateAlbum(AlbumBLL albumBLL, AuthorBLL authorBLL, IEnumerable<TrackBLL> tracksBLL, IEnumerable<GenreBLL> genresBLL);
        void UpdateAuthor(AuthorBLL authorBLL, IEnumerable<TrackBLL> tracksBLL, IEnumerable<AlbumBLL> authorsBLL, IEnumerable<GenreBLL> genresBLL);

        void PostTrackRate(TrackRateBLL trackRateBLL);
        void PostAlbumRate(AlbumRateBLL albumRateBLL);

        void DeleteTrackRate(TrackRateBLL trackRateBLL);
        void DeleteAlbumRate(AlbumRateBLL albumRateBLL);
    
        void DeleteTrack(int id);
        void DeleteGenre(int id);
        void DeleteAuthor(int id);
        void DeleteAlbum(int id);

    }
}
