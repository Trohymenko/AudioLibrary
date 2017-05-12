using System;
using System.Collections.Generic;
using System.Linq;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IGetInfoService
    {
        TrackDTO GetTrack(int id);
        AuthorDTO GetAuthor(int id);
        AlbumDTO GetAlbum(int id);
        GenreDTO GetGenre(int id);
 
        IEnumerable<TrackDTO> GetAllTracks();
        IEnumerable<AuthorDTO> GetAllAuthors();
        IEnumerable<AlbumDTO> GetAllAlbums();
        IEnumerable<GenreDTO> GetAllGenres();

        TrackDTO FindTrack(string field, string value);
        AuthorDTO FindAuthor(string field, string value);
        AlbumDTO FindAlbum(string field, string value);
        GenreDTO FindGenre(string field, string value);

        IEnumerable<TrackDTO> GetTracksByAuthor(string category);
        IEnumerable<TrackDTO> GetTracksByGenre(string category);
        IEnumerable<TrackDTO> GetTracksByAlbum(string name);

    }
}
