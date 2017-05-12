using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using Ninject;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;

namespace BLL.Services
{
    public class ModifyService : IModifyService
    {
        ITracksUnitOfWork Database { get; set; }
        public static IKernel kernel;
        public ModifyService(string connectionstring)
        {
            kernel = new StandardKernel(new ServiceModule(connectionstring));
            Database = kernel.Get<ITracksUnitOfWork>();
        }
        public void CreateTrack(TrackDTO trackDTO, AuthorDTO authorDTO, IEnumerable<GenreDTO> genresDTO, IEnumerable<AlbumDTO> albumsDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, Track>());
            Track track = Mapper.Map<TrackDTO, Track>(trackDTO);

            if (genresDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreDTO, Genre>());
                track.Genres = Mapper.Map<IEnumerable<GenreDTO>, IEnumerable<Genre>>(genresDTO).ToList();
            }

            if (albumsDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumDTO, Album>());
                track.Albums = Mapper.Map<IEnumerable<AlbumDTO>, IEnumerable<Album>>(albumsDTO).ToList();
            }
            Database.Tracks.Create(track);
        }

        public void CreateAuthor(AuthorDTO authorDTO, IEnumerable<GenreDTO> genresDTO
            , IEnumerable<AlbumDTO> albumsDTO, IEnumerable<TrackDTO> tracksDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, Author>());
            Author author = Mapper.Map<AuthorDTO, Author>(authorDTO);

            if (genresDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreDTO, Genre>());
                author.Genres = Mapper.Map<IEnumerable<GenreDTO>, IEnumerable<Genre>>(genresDTO).ToList();
            }

            if (albumsDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumDTO, Album>());
                author.Albums = Mapper.Map<IEnumerable<AlbumDTO>, IEnumerable<Album>>(albumsDTO).ToList();
            }
            if (tracksDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, Track>());
                author.Tracks = Mapper.Map<IEnumerable<TrackDTO>, IEnumerable<Track>>(tracksDTO).ToList();
            }
        }
        public void CreateAlbum(AlbumDTO albumDTO,AuthorDTO authorDTO,
            IEnumerable<GenreDTO> genresDTO, IEnumerable<TrackDTO> tracksDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AlbumDTO, Album>());
            Album album = Mapper.Map<AlbumDTO, Album>(albumDTO);

            if (genresDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreDTO, Genre>());
                album.Genres = Mapper.Map<IEnumerable<GenreDTO>, IEnumerable<Genre>>(genresDTO).ToList();
            }

            if (authorDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, Author>());
                album.Author = Mapper.Map<AuthorDTO, Author>(authorDTO);
            }
            if (tracksDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, Track>());
                album.Tracks = Mapper.Map<IEnumerable<TrackDTO>, IEnumerable<Track>>(tracksDTO).ToList();
            }
        }
        public void CreateGenre(GenreDTO genreDTO, IEnumerable<TrackDTO> tracksDTO, IEnumerable<AlbumDTO> albumsDTO, IEnumerable<AuthorDTO> authorsDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<GenreDTO, Genre>());
            Genre genre = Mapper.Map<GenreDTO, Genre>(genreDTO);

            if (albumsDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumDTO, Album>());
                genre.Albums = Mapper.Map<IEnumerable<AlbumDTO>, IEnumerable<Album>>(albumsDTO).ToList();
            }

            if (authorsDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, Author>());
                genre.Authors = Mapper.Map<IEnumerable<AuthorDTO>, IEnumerable<Author>>(authorsDTO).ToList();
            }
            if (tracksDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, Track>());
                genre.Tracks = Mapper.Map<IEnumerable<TrackDTO>, IEnumerable<Track>>(tracksDTO).ToList();
            }
        }
        public void UpdateTrack(TrackDTO trackDTO, AuthorDTO authorDTO, IEnumerable<GenreDTO> genresDTO, IEnumerable<AlbumDTO> albumsDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, Track>());
            Track track = Mapper.Map<TrackDTO, Track>(trackDTO);

            if (genresDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreDTO, Genre>());
                track.Genres = Mapper.Map<IEnumerable<GenreDTO>, IEnumerable<Genre>>(genresDTO).ToList();
            }

            if (albumsDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumDTO, Album>());
                track.Albums = Mapper.Map<IEnumerable<AlbumDTO>, IEnumerable<Album>>(albumsDTO).ToList();
            }
            Database.Tracks.Update(track);
        }
        public void UpdateAuthor(AuthorDTO authorDTO, IEnumerable<TrackDTO> tracksDTO, IEnumerable<AlbumDTO> albumsDTO, IEnumerable<GenreDTO> genresDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, Author>());
            Author author = Mapper.Map<AuthorDTO, Author>(authorDTO);

            if (genresDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreDTO, Genre>());
                author.Genres = Mapper.Map<IEnumerable<GenreDTO>, IEnumerable<Genre>>(genresDTO).ToList();
            }

            if (albumsDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumDTO, Album>());
                author.Albums = Mapper.Map<IEnumerable<AlbumDTO>, IEnumerable<Album>>(albumsDTO).ToList();
            }
            if (tracksDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, Track>());
                author.Tracks = Mapper.Map<IEnumerable<TrackDTO>, IEnumerable<Track>>(tracksDTO).ToList();
            }

            Database.Authors.Update(author);
        }
        public void UpdateAlbum(AlbumDTO albumDTO, AuthorDTO authorDTO, IEnumerable<TrackDTO> tracksDTO, IEnumerable<GenreDTO> genresDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AlbumDTO, Album>());
            Album album = Mapper.Map<AlbumDTO, Album>(albumDTO);

            if (genresDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreDTO, Genre>());
                album.Genres = Mapper.Map<IEnumerable<GenreDTO>, IEnumerable<Genre>>(genresDTO).ToList();
            }         
            if (tracksDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, Track>());
                album.Tracks = Mapper.Map<IEnumerable<TrackDTO>, IEnumerable<Track>>(tracksDTO).ToList();
            }
            if (authorDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, Author>());
                album.Author = Mapper.Map<AuthorDTO, Author>(authorDTO);
            }

            Database.Albums.Update(album);
        }
        public void UpdateGenre(GenreDTO genreDTO, IEnumerable<TrackDTO> tracksDTO, IEnumerable<AlbumDTO> albumsDTO, IEnumerable<AuthorDTO> authorsDTO)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<GenreDTO, Genre>());
            Genre genre = Mapper.Map<GenreDTO, Genre>(genreDTO);

            if (albumsDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumDTO, Album>());
                genre.Albums = Mapper.Map<IEnumerable<AlbumDTO>, IEnumerable<Album>>(albumsDTO).ToList();
            }
            if (tracksDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackDTO, Track>());
                genre.Tracks = Mapper.Map<IEnumerable<TrackDTO>, IEnumerable<Track>>(tracksDTO).ToList();
            }
            if (authorsDTO != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorDTO, Author>());
                genre.Authors = Mapper.Map<IEnumerable<AuthorDTO>, IEnumerable<Author>>(authorsDTO).ToList();
            }

            Database.Genres.Update(genre);
        }
        public void DeleteTrack(int id)
        {
            Database.Tracks.Delete(id);
        }
        public void DeleteAuthor(int id)
        {
            Database.Authors.Delete(id);
        }
        public void DeleteAlbum(int id)
        {
            Database.Albums.Delete(id);
        }
        public void DeleteGenre(int id)
        {
            Database.Genres.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
