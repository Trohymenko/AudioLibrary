using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using Ninject;
using AutoMapper;
using BLL.Entities;
using BLL.Infrastructure;
using BLL.Interfaces;

namespace BLL.Services
{
    public class ModifyService : IModifyService
    {
        ITracksUnitOfWork TracksDB { get; set; }
        IRatesUnitOfWork RatesDB { get; set; }

        public static IKernel kernel;
        public ModifyService(string connectionstring)
        {
            kernel = new StandardKernel(new ServiceModule(connectionstring));
            TracksDB = kernel.Get<ITracksUnitOfWork>();
            RatesDB = kernel.Get<IRatesUnitOfWork>();
        }
        public void CreateTrack(TrackBLL trackBLL, AuthorBLL authorBLL, IEnumerable<GenreBLL> genresBLL, IEnumerable<AlbumBLL> albumsBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, Track>());
            Track track = Mapper.Map<TrackBLL, Track>(trackBLL);

            if (genresBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, Genre>());
                track.Genres = Mapper.Map<IEnumerable<GenreBLL>, IEnumerable<Genre>>(genresBLL).ToList();
            }

            if (albumsBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, Album>());
                track.Albums = Mapper.Map<IEnumerable<AlbumBLL>, IEnumerable<Album>>(albumsBLL).ToList();
            }
            TracksDB.Tracks.Create(track);
        }

        public void CreateAuthor(AuthorBLL authorBLL, IEnumerable<GenreBLL> genresBLL
            , IEnumerable<AlbumBLL> albumsBLL, IEnumerable<TrackBLL> tracksBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, Author>());
            Author author = Mapper.Map<AuthorBLL, Author>(authorBLL);

            if (genresBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, Genre>());
                author.Genres = Mapper.Map<IEnumerable<GenreBLL>, IEnumerable<Genre>>(genresBLL).ToList();
            }

            if (albumsBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, Album>());
                author.Albums = Mapper.Map<IEnumerable<AlbumBLL>, IEnumerable<Album>>(albumsBLL).ToList();
            }
            if (tracksBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, Track>());
                author.Tracks = Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<Track>>(tracksBLL).ToList();
            }
        }
        public void CreateAlbum(AlbumBLL albumBLL,AuthorBLL authorBLL,
            IEnumerable<GenreBLL> genresBLL, IEnumerable<TrackBLL> tracksBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, Album>());
            Album album = Mapper.Map<AlbumBLL, Album>(albumBLL);

            if (genresBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, Genre>());
                album.Genres = Mapper.Map<IEnumerable<GenreBLL>, IEnumerable<Genre>>(genresBLL).ToList();
            }

            if (authorBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, Author>());
                album.Author = Mapper.Map<AuthorBLL, Author>(authorBLL);
            }
            if (tracksBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, Track>());
                album.Tracks = Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<Track>>(tracksBLL).ToList();
            }
        }
        public void CreateGenre(GenreBLL genreBLL, IEnumerable<TrackBLL> tracksBLL, IEnumerable<AlbumBLL> albumsBLL, IEnumerable<AuthorBLL> authorsBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, Genre>());
            Genre genre = Mapper.Map<GenreBLL, Genre>(genreBLL);

            if (albumsBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, Album>());
                genre.Albums = Mapper.Map<IEnumerable<AlbumBLL>, IEnumerable<Album>>(albumsBLL).ToList();
            }

            if (authorsBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, Author>());
                genre.Authors = Mapper.Map<IEnumerable<AuthorBLL>, IEnumerable<Author>>(authorsBLL).ToList();
            }
            if (tracksBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, Track>());
                genre.Tracks = Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<Track>>(tracksBLL).ToList();
            }
            TracksDB.Genres.Create(genre);
        }
        public void UpdateTrack(TrackBLL trackBLL, AuthorBLL authorBLL, IEnumerable<GenreBLL> genresBLL, IEnumerable<AlbumBLL> albumsBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, Track>());
            Track track = Mapper.Map<TrackBLL, Track>(trackBLL);

            if (genresBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, Genre>());
                track.Genres = Mapper.Map<IEnumerable<GenreBLL>, IEnumerable<Genre>>(genresBLL).ToList();
            }

            if (albumsBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, Album>());
                track.Albums = Mapper.Map<IEnumerable<AlbumBLL>, IEnumerable<Album>>(albumsBLL).ToList();
            }
            TracksDB.Tracks.Update(track);
        }
        public void UpdateAuthor(AuthorBLL authorBLL, IEnumerable<TrackBLL> tracksBLL, IEnumerable<AlbumBLL> albumsBLL, IEnumerable<GenreBLL> genresBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, Author>());
            Author author = Mapper.Map<AuthorBLL, Author>(authorBLL);

            if (genresBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, Genre>());
                author.Genres = Mapper.Map<IEnumerable<GenreBLL>, IEnumerable<Genre>>(genresBLL).ToList();
            }

            if (albumsBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, Album>());
                author.Albums = Mapper.Map<IEnumerable<AlbumBLL>, IEnumerable<Album>>(albumsBLL).ToList();
            }
            if (tracksBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, Track>());
                author.Tracks = Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<Track>>(tracksBLL).ToList();
            }

            TracksDB.Authors.Update(author);
        }
        public void UpdateAlbum(AlbumBLL albumBLL, AuthorBLL authorBLL, IEnumerable<TrackBLL> tracksBLL, IEnumerable<GenreBLL> genresBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, Album>());
            Album album = Mapper.Map<AlbumBLL, Album>(albumBLL);

            if (genresBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, Genre>());
                album.Genres = Mapper.Map<IEnumerable<GenreBLL>, IEnumerable<Genre>>(genresBLL).ToList();
            }         
            if (tracksBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, Track>());
                album.Tracks = Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<Track>>(tracksBLL).ToList();
            }
            if (authorBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, Author>());
                album.Author = Mapper.Map<AuthorBLL, Author>(authorBLL);
            }

            TracksDB.Albums.Update(album);
        }
        public void UpdateGenre(GenreBLL genreBLL, IEnumerable<TrackBLL> tracksBLL, IEnumerable<AlbumBLL> albumsBLL, IEnumerable<AuthorBLL> authorsBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<GenreBLL, Genre>());
            Genre genre = Mapper.Map<GenreBLL, Genre>(genreBLL);

            if (albumsBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AlbumBLL, Album>());
                genre.Albums = Mapper.Map<IEnumerable<AlbumBLL>, IEnumerable<Album>>(albumsBLL).ToList();
            }
            if (tracksBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TrackBLL, Track>());
                genre.Tracks = Mapper.Map<IEnumerable<TrackBLL>, IEnumerable<Track>>(tracksBLL).ToList();
            }
            if (authorsBLL != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<AuthorBLL, Author>());
                genre.Authors = Mapper.Map<IEnumerable<AuthorBLL>, IEnumerable<Author>>(authorsBLL).ToList();
            }

            TracksDB.Genres.Update(genre);
        }
        public void PostTrackRate(TrackRateBLL trackRateBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TrackRateBLL, TrackRate>());
            TrackRate trackRate = Mapper.Map<TrackRateBLL, TrackRate>(trackRateBLL);
            RatesDB.TracksRates.Create(trackRate);
        }
        public void PostAlbumRate(AlbumRateBLL albumRateBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AlbumRateBLL, AlbumRate>());
            AlbumRate albumRate = Mapper.Map<AlbumRateBLL, AlbumRate>(albumRateBLL);
            RatesDB.AlbumsRates.Delete(albumRate.AlbumRateId);
        }

        public void DeleteTrackRate(TrackRateBLL trackRateBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<TrackRateBLL, TrackRate>());
            TrackRate trackRate = Mapper.Map<TrackRateBLL, TrackRate>(trackRateBLL);
            RatesDB.TracksRates.Delete(trackRate.TrackRateId);
        }
        public void DeleteAlbumRate(AlbumRateBLL albumRateBLL)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AlbumRateBLL, AlbumRate>());
            AlbumRate albumRate = Mapper.Map<AlbumRateBLL, AlbumRate>(albumRateBLL);
            RatesDB.AlbumsRates.Delete(albumRate.AlbumRateId);
        }

        public void DeleteTrack(int id)
        {
             TracksDB.Tracks.Delete(id);
        }
        public void DeleteAuthor(int id)
        {
            TracksDB.Authors.Delete(id);
        }
        public void DeleteAlbum(int id)
        {
            TracksDB.Albums.Delete(id);
        }
        public void DeleteGenre(int id)
        {
            TracksDB.Genres.Delete(id);
        }

        public void Dispose()
        {
            TracksDB.Dispose();
            RatesDB.Dispose();
        }
    }
}
