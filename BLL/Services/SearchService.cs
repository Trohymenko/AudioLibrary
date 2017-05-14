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
using System.Text.RegularExpressions;

namespace BLL.Services
{
    public class SearchService : ISearchService
    {
        ITracksUnitOfWork Database { get; set; }
        public static IKernel kernel;
        public SearchService(string connectionstring)
        {
            kernel = new StandardKernel(new ServiceModule(connectionstring));
            Database = kernel.Get<ITracksUnitOfWork>();
        }

        public IEnumerable<TrackBLL> SearchForTrack(string category, string name)
        {
            {
                IEnumerable<Track> tracksDbResult = Database.Tracks.GetAll(track =>
                Regex.IsMatch(track.TrackName, name, RegexOptions.IgnoreCase));

                if (tracksDbResult.Count() > 0)
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>()
                    .ForMember(trackbll => trackbll.AuthorName, src => src.MapFrom(track => track.Author.AuthorName))
                     .ForMember(trackbll => trackbll.TrackRateAverage, src =>
                      src.MapFrom(track => Math.Round(track.TrackRates.Sum(rate => rate.TrackRateValue) / (double)track.TrackRates.Count() , MidpointRounding.AwayFromZero)
                      )));

                    return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBLL>>(tracksDbResult).ToList();
                }
                else throw new Exception();
            }
        }
        public IEnumerable<AuthorBLL> SearchForAuthor(string category, string name)
        {
            {
                IEnumerable<Author> authorDbResult = Database.Authors.GetAll(author =>
                Regex.IsMatch(author.AuthorName, name, RegexOptions.IgnoreCase));

                if (authorDbResult.Count() > 0)
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<Author, AuthorBLL>());
                    return Mapper.Map<IEnumerable<Author>, IEnumerable<AuthorBLL>>(authorDbResult).ToList();
                }
                else throw new Exception();
            }
        }
        public IEnumerable<AlbumBLL> SearchForAlbum(string category, string name)
        {
            {
                IEnumerable<Album> albumsDbResult = Database.Albums.GetAll(album =>
                Regex.IsMatch(album.AlbumName, name, RegexOptions.IgnoreCase));

                if (albumsDbResult.Count() > 0)
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<Album, AlbumBLL>());
                    return Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBLL>>(albumsDbResult).ToList();
                }
                else throw new Exception();
            }
        }
        public IEnumerable<GenreBLL> SearchForGenre(string category, string name)
        {
            {
                IEnumerable<Genre> genreDbResult = Database.Genres.GetAll(genre =>
                Regex.IsMatch(genre.GenreName, name, RegexOptions.IgnoreCase));

                if (genreDbResult.Count() > 0)
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<Genre, GenreBLL>());
                    return Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreBLL>>(genreDbResult).ToList();
                }
                else throw new Exception();
            }
        }
    }
}

