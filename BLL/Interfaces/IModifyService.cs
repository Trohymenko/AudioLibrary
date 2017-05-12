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
        void CreateTrack(TrackDTO trackDTO, IEnumerable<GenreDTO> genres, IEnumerable<AlbumDTO> albums);
        void CreateGenre(GenreDTO genreDTO, IEnumerable<TrackDTO> tracks, IEnumerable<AlbumDTO> albums, IEnumerable<AuthorDTO> authors);
        void CreateAuthor(AuthorDTO authorDTO, IEnumerable<GenreDTO> genres, IEnumerable<AlbumDTO> albums, IEnumerable<TrackDTO> tracks);
        void UpdateTrack(TrackDTO trackDTO, IEnumerable<GenreDTO> genres, IEnumerable<AlbumDTO> albums);
        void DeleteTrack(int id);

    }
}
