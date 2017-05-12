using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using Ninject;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using System.Linq.Expressions;

namespace BLL.Services
{
    public class GetInfoService : IGetInfoService
    {
        ITracksUnitOfWork Database { get; set; }
        public static IKernel kernel;

        public GetInfoService(string connectionstring)
        {
            kernel = new StandardKernel(new ServiceModule(connectionstring));
            Database = kernel.Get<ITracksUnitOfWork>();
        }
        public IEnumerable<TrackDTO> GetAllTracks(Func<TrackDTO, bool> predicate)
        {
            //todo
            return null;
        }
        public IEnumerable<TrackDTO> GetAllTracks()
        {
            IEnumerable<Track> trackList = Database.Tracks.GetAll();
            if (trackList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackDTO>());
                return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackDTO>>(trackList);
            }
            else throw new Exception();
        }

        public IEnumerable<AlbumDTO> GetAllAlbums()
        {
            IEnumerable<Album> albumList = Database.Albums.GetAll();
            if (albumList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumDTO>());
                return Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumDTO>>(albumList);
            }
            else throw new Exception();
        }

        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            IEnumerable<Author> authorList = Database.Authors.GetAll();
            if (authorList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorDTO>());
                return Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(authorList);
            }
            else throw new Exception();
        }
        public IEnumerable<GenreDTO> GetAllGenres()
        {
            IEnumerable<Genre> authorList = Database.Genres.GetAll();
            if (authorList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreDTO>());
                return Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(authorList);
            }
            else throw new Exception();
        }

        public TrackDTO GetTrack(int id)
        {
            Track track = Database.Tracks.Get(id);
            if (track != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackDTO>());
                return Mapper.Map<Track, TrackDTO>(track);
            }
            else throw new Exception();
        }

        public AuthorDTO GetAuthor(int id)
        {
            Author author = Database.Authors.Get(id);
            if (author != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorDTO>());
                return Mapper.Map<Author, AuthorDTO>(author);
            }
            else throw new Exception();
        }

        public AlbumDTO GetAlbum(int id)
        {
            Album album = Database.Albums.Get(id);
            if (album != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumDTO>());
                return Mapper.Map<Album, AlbumDTO>(album);
            }
            else throw new Exception();
        }
        public GenreDTO GetGenre(int id)
        {
            Genre genre = Database.Genres.Get(id);
            if (genre != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreDTO>());
                return Mapper.Map<Genre, GenreDTO>(genre);
            }
            else throw new Exception();
        }
        public IEnumerable<TrackDTO> GetTracksByAuthor(string name)
        {
            IEnumerable<Track> trackList = Database.Tracks.GetAll().Where(x => x.Author.AuthorName == name).ToList();
            if (trackList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackDTO>());
                return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackDTO>>(trackList);
            }
            else throw new Exception();
        }
        public IEnumerable<TrackDTO> GetTracksByGenre(string name)
        {
            IEnumerable<Track> trackList = Database.Genres.GetAll()
                .Select(genre => genre.Tracks).FirstOrDefault();
            if (trackList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackDTO>());
                return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackDTO>>(trackList);
            }
            else throw new Exception();
        }
        public IEnumerable<TrackDTO> GetTracksByAlbum(string name)
        {
            IEnumerable<Track> trackList = Database.Albums.GetAll().Where(x => x.AlbumName == name)
                .Select(album => album.Tracks).FirstOrDefault();
            if (trackList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackDTO>());
                return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackDTO>>(trackList);
            }
            else throw new Exception();
        }
        public TrackDTO FindTrack(string field, string value)
        {          
            Func<Track, Boolean> predicate;
            Track trackResult = null;
            switch (field)
            {
                case "Name":
                    predicate = track => track.TrackName == value;
                    trackResult = Database.Tracks.Find(predicate);
                    if (trackResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackDTO>());
                        return Mapper.Map<Track, TrackDTO>(trackResult);
                    }
                    else throw new Exception("Not found");
                case "ID":
                    predicate = track => track.TrackID == Int32.Parse(value);
                    trackResult = Database.Tracks.Find(predicate);
                    if (trackResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackDTO>());
                        return Mapper.Map<Track, TrackDTO>(trackResult);
                    }
                    else throw new Exception("Not found");
                case "AuthorID":
                    predicate = track => track.AuthorID == Int32.Parse(value);
                    trackResult = Database.Tracks.Find(predicate);
                    if (trackResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackDTO>());
                        return Mapper.Map<Track, TrackDTO>(trackResult);
                    }
                    else throw new Exception("Not found");
            }
            throw new Exception("There is no such field");        
        }
        public AuthorDTO FindAuthor(string field, string value)
        {
            Func<Author, Boolean> predicate;
            Author authorResult = null;
            switch (field)
            {
                case "Name":
                    predicate = author => author.AuthorName == value;
                    authorResult = Database.Authors.Find(predicate);
                    if (authorResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorDTO>());
                        return Mapper.Map<Author, AuthorDTO>(authorResult);
                    }
                    else throw new Exception("Not found");
                case "Id":
                    predicate = author => author.AuthorID == Int32.Parse(value);
                    authorResult = Database.Authors.Find(predicate);
                    if (authorResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Track, AuthorDTO>());
                        return Mapper.Map<Author, AuthorDTO>(authorResult);
                    }
                    else throw new Exception("Not found");
            }
            throw new Exception("There is no such field");
        }
        public AlbumDTO FindAlbum(string field, string value)
        {
            Func<Album, Boolean> predicate;
            Album albumResult = null;
            switch (field)
            {
                case "Name":
                    predicate = album => album.AlbumName == value;
                    albumResult = Database.Albums.Find(predicate);
                    if (albumResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumDTO>());
                        return Mapper.Map<Album, AlbumDTO>(albumResult);
                    }
                    else throw new Exception("Not found");
                case "ID":
                    predicate = album => album.AlbumId == Int32.Parse(value);
                    albumResult = Database.Albums.Find(predicate);
                    if (albumResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumDTO>());
                        return Mapper.Map<Album, AlbumDTO>(albumResult);
                    }
                    else throw new Exception("Not found");
                case "AuthorID":
                    predicate = album => album.AuthorID == Int32.Parse(value);
                    albumResult = Database.Albums.Find(predicate);
                    if (albumResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumDTO>());
                        return Mapper.Map<Album, AlbumDTO>(albumResult);
                    }
                    else throw new Exception("Not found");
            }
            throw new Exception("There is no such field");
        }
        public GenreDTO FindGenre(string field, string value)
        {
            Func<Genre, Boolean> predicate;
            Genre genreResult = null;
            switch (field)
            {
                case "Name":
                    predicate = genre => genre.GenreName == value;
                    genreResult = Database.Genres.Find(predicate);
                    if (genreResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreDTO>());
                        return Mapper.Map<Genre, GenreDTO>(genreResult);
                    }
                    else throw new Exception("Not found");
                case "Id":
                    predicate = genre => genre.GenreId == Int32.Parse(value);
                    genreResult = Database.Genres.Find(predicate);
                    if (genreResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreDTO>());
                        return Mapper.Map<Genre, GenreDTO>(genreResult);
                    }
                    else throw new Exception("Not found");   
            }
            throw new Exception("There is no such field");
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
