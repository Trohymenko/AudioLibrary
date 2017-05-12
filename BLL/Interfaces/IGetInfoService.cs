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

        IEnumerable<TrackDTO> GetTracksByAuthor(string category);
        IEnumerable<TrackDTO> GetTracksByGenre(string category);
        IEnumerable<TrackDTO> GetTracksByAlbum(string name);

    }
}
