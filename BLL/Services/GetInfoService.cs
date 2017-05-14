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
using BLL.Entities;
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
        public IEnumerable<TrackBLL> GetAllTracks(Func<TrackBLL, bool> predicate)
        {
            //todo
            return null;
        }
        public IEnumerable<TrackBLL> GetAllTracks()
        {
            IEnumerable<Track> trackList = Database.Tracks.GetAll(track => true);
            if (trackList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>()
                .ForMember(trackbll => trackbll.AuthorName,src => src.MapFrom(track => track.Author.AuthorName))

                .ForMember(trackbll => trackbll.TrackRateAverage, src=>
                src.MapFrom(track => track.TrackRates.Sum(rate=>rate.TrackRateValue)/track.TrackRates.Count())));

                return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBLL>>(trackList);
            }
            else throw new Exception();
        }

        public IEnumerable<AlbumBLL> GetAllAlbums()
        {
            IEnumerable<Album> albumList = Database.Albums.GetAll(album => true);
            if (albumList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumBLL>());
                return Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBLL>>(albumList);
            }
            else throw new Exception();
        }

        public IEnumerable<AuthorBLL> GetAllAuthors()
        {
            IEnumerable<Author> authorList = Database.Authors.GetAll(author => true);
            if (authorList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorBLL>());
                return Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorBLL>>(authorList);
            }
            else throw new Exception();
        }
        public IEnumerable<GenreBLL> GetAllGenres()
        {
            IEnumerable<Genre> authorList = Database.Genres.GetAll(author => true);
            if (authorList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreBLL>());
                return Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreBLL>>(authorList);
            }
            else throw new Exception();
        }

        public IEnumerable<TrackRateBLL> GetTrackRate(string name)
        {
            IEnumerable<TrackRate> trackRatesDb = Database.Tracks.GetAll(track => track.TrackName == name).FirstOrDefault().TrackRates;
            Mapper.Initialize(cfg => cfg.CreateMap<TrackRate, TrackRateBLL>());
            return Mapper.Map<IEnumerable<TrackRate>, IEnumerable<TrackRateBLL>>(trackRatesDb);


        }

        public IEnumerable<AlbumRateBLL> GetAlbumRate(string name)
        {
            return null;
        }

        public TrackBLL GetTrack(int id)
        {
            Track track = Database.Tracks.Get(id);
            if (track != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>());
                return Mapper.Map<Track, TrackBLL>(track);
            }
            else throw new Exception();
        }

        public AuthorBLL GetAuthor(int id)
        {
            Author author = Database.Authors.Get(id);
            if (author != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorBLL>());
                return Mapper.Map<Author, AuthorBLL>(author);
            }
            else throw new Exception();
        }

        public AlbumBLL GetAlbum(int id)
        {
            Album album = Database.Albums.Get(id);
            if (album != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumBLL>());
                return Mapper.Map<Album, AlbumBLL>(album);
            }
            else throw new Exception();
        }
        public GenreBLL GetGenre(int id)
        {
            Genre genre = Database.Genres.Get(id);
            if (genre != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreBLL>());
                return Mapper.Map<Genre, GenreBLL>(genre);
            }
            else throw new Exception();
        }
        public IEnumerable<TrackBLL> GetTracksByAuthor(string name)
        {
            IEnumerable<Track> trackList = Database.Tracks.GetAll(track=>true).Where(x => x.Author.AuthorName == name).ToList();
            if (trackList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>());
                return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBLL>>(trackList);
            }
            else throw new Exception();
        }
        public IEnumerable<TrackBLL> GetTracksByGenre(string name)
        {
            IEnumerable<Track> trackList = Database.Genres.GetAll(genre=>true)
                .Select(genre => genre.Tracks).FirstOrDefault();
            if (trackList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>());
                return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBLL>>(trackList);
            }
            else throw new Exception();
        }
        public IEnumerable<TrackBLL> GetTracksByAlbum(string name)
        {
            IEnumerable<Track> trackList = Database.Albums.GetAll(album=>true).Where(album => album.AlbumName == name)
                .Select(album => album.Tracks).FirstOrDefault();
            if (trackList != null)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>());
                return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBLL>>(trackList);
            }
            else throw new Exception();
        }
        public TrackBLL FindTrack(string field, string value)
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
                        Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>());
                        return Mapper.Map<Track, TrackBLL>(trackResult);
                    }
                    else throw new Exception("Not found");
                case "ID":
                    predicate = track => track.TrackID == Int32.Parse(value);
                    trackResult = Database.Tracks.Find(predicate);
                    if (trackResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>());
                        return Mapper.Map<Track, TrackBLL>(trackResult);
                    }
                    else throw new Exception("Not found");
                case "AuthorID":
                    predicate = track => track.AuthorID == Int32.Parse(value);
                    trackResult = Database.Tracks.Find(predicate);
                    if (trackResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>());
                        return Mapper.Map<Track, TrackBLL>(trackResult);
                    }
                    else throw new Exception("Not found");
            }
            throw new Exception("There is no such field");        
        }
        public AuthorBLL FindAuthor(string field, string value)
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
                        Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorBLL>());
                        return Mapper.Map<Author, AuthorBLL>(authorResult);
                    }
                    else throw new Exception("Not found");
                case "Id":
                    predicate = author => author.AuthorID == Int32.Parse(value);
                    authorResult = Database.Authors.Find(predicate);
                    if (authorResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Track, AuthorBLL>());
                        return Mapper.Map<Author, AuthorBLL>(authorResult);
                    }
                    else throw new Exception("Not found");
            }
            throw new Exception("There is no such field");
        }
        public AlbumBLL FindAlbum(string field, string value)
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
                        Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumBLL>());
                        return Mapper.Map<Album, AlbumBLL>(albumResult);
                    }
                    else throw new Exception("Not found");
                case "ID":
                    predicate = album => album.AlbumId == Int32.Parse(value);
                    albumResult = Database.Albums.Find(predicate);
                    if (albumResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumBLL>());
                        return Mapper.Map<Album, AlbumBLL>(albumResult);
                    }
                    else throw new Exception("Not found");
                case "AuthorID":
                    predicate = album => album.AuthorID == Int32.Parse(value);
                    albumResult = Database.Albums.Find(predicate);
                    if (albumResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumBLL>());
                        return Mapper.Map<Album, AlbumBLL>(albumResult);
                    }
                    else throw new Exception("Not found");
            }
            throw new Exception("There is no such field");
        }
        public GenreBLL FindGenre(string field, string value)
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
                        Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreBLL>());
                        return Mapper.Map<Genre, GenreBLL>(genreResult);
                    }
                    else throw new Exception("Not found");
                case "Id":
                    predicate = genre => genre.GenreId == Int32.Parse(value);
                    genreResult = Database.Genres.Find(predicate);
                    if (genreResult != null)
                    {
                        Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreBLL>());
                        return Mapper.Map<Genre, GenreBLL>(genreResult);
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
