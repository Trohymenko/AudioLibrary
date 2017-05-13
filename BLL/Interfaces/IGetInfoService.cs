using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Entities;

namespace BLL.Interfaces
{
    public interface IGetInfoService
    {
        TrackBLL GetTrack(int id);
        AuthorBLL GetAuthor(int id);
        AlbumBLL GetAlbum(int id);
        GenreBLL GetGenre(int id);
 
        IEnumerable<TrackBLL> GetAllTracks();
        IEnumerable<AuthorBLL> GetAllAuthors();
        IEnumerable<AlbumBLL> GetAllAlbums();
        IEnumerable<GenreBLL> GetAllGenres();

        IEnumerable<TrackRateBLL> GetTrackRate(string name);
        IEnumerable<AlbumRateBLL> GetAlbumRate(string name);

        TrackBLL FindTrack(string field, string value);
        AuthorBLL FindAuthor(string field, string value);
        AlbumBLL FindAlbum(string field, string value);
        GenreBLL FindGenre(string field, string value);

        IEnumerable<TrackBLL> GetTracksByAuthor(string category);
        IEnumerable<TrackBLL> GetTracksByGenre(string category);
        IEnumerable<TrackBLL> GetTracksByAlbum(string name);

    }
}
