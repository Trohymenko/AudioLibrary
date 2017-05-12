using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IModifyService
    {
        void CreateTrack(TrackDTO trackDTO, AuthorDTO authorDTO,IEnumerable<GenreDTO> genresDTO, IEnumerable<AlbumDTO> albumsDTO);
        void CreateGenre(GenreDTO genreDTO, IEnumerable<TrackDTO> tracksDTO, IEnumerable<AlbumDTO> albumsDTO, IEnumerable<AuthorDTO> authorsDTO);
        void CreateAuthor(AuthorDTO authorDTO, IEnumerable<GenreDTO> genresDTO, IEnumerable<AlbumDTO> albumsDTO, IEnumerable<TrackDTO> tracksDTO);
        void CreateAlbum(AlbumDTO albumDTO, AuthorDTO authorDTO, IEnumerable<GenreDTO> genresDTO, IEnumerable<TrackDTO> tracksDTO);

        void UpdateTrack(TrackDTO trackDTO, AuthorDTO authorDTO, IEnumerable<GenreDTO> genresDTO, IEnumerable<AlbumDTO> albumsDTO);
        void UpdateGenre(GenreDTO genreDTO, IEnumerable<TrackDTO> tracksDTO, IEnumerable<AlbumDTO> albumsDTO, IEnumerable<AuthorDTO> authorsDTO);
        void UpdateAlbum(AlbumDTO albumDTO, AuthorDTO authorDTO, IEnumerable<TrackDTO> tracksDTO, IEnumerable<GenreDTO> genresDTO);
        void UpdateAuthor(AuthorDTO authorDTO, IEnumerable<TrackDTO> tracksDTO, IEnumerable<AlbumDTO> authorsDTO, IEnumerable<GenreDTO> genresDTO);

        void DeleteTrack(int id);
        void DeleteGenre(int id);
        void DeleteAuthor(int id);
        void DeleteAlbum(int id);

    }
}
