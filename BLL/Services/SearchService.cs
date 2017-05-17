using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Entities;
using Ninject;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Entities;
using AutoMapper;


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

        public IEnumerable<TrackBLL> Search(string term, string category)
        {
            {
                IEnumerable<Track> tracksDbResult = null;
                switch (category)
                {
                    case "Tracks":

                        tracksDbResult = Database.Tracks.Get(track => track.TrackName.Contains(term));
                        if (tracksDbResult.Count() == 0)
                        {
                            throw new NullQueryResultException("Search result is null in tracks");
                        }
                        break;

                    case "Authors":

                        IEnumerable<Author> authorsDb = Database.Authors.Get(author => author.AuthorName.Contains(term));
                        if (authorsDb.Count() == 0)
                        {
                            throw new NullQueryResultException("Search result is null in authors");
                        }
                        foreach (var author in authorsDb)
                        {
                            bool initialized = false;
                            tracksDbResult = author.Tracks;
                            if (initialized)
                            {
                                tracksDbResult = tracksDbResult.Concat(author.Tracks);
                            }
                            initialized = true;
                        }
                        break;
                    case "Albums":

                        IEnumerable<Album> albumsDb = Database.Albums.Get(album => album.AlbumName.Contains(term));
                        if (albumsDb.Count() == 0)
                        {
                             throw new NullQueryResultException("Search result is null in albums");
                        }
                        foreach (var album in albumsDb)
                        {
                            bool initialized = false;
                            tracksDbResult = album.Tracks;
                            if (initialized)
                            {
                                tracksDbResult = tracksDbResult.Concat(album.Tracks);
                            }
                            initialized = true;
                        }
                        break;

                    case "Genres":
                        IEnumerable<Genre> genresDb = Database.Genres.Get(genre => genre.GenreName.Contains(term));
                        if (genresDb.Count() == 0)
                        {
                            throw new NullQueryResultException("Search result is null in genres");
                        }
                        foreach (var genre in genresDb)
                        {
                            bool initialized = false;
                            tracksDbResult = genre.Tracks;
                            if (initialized)
                            {
                                tracksDbResult = tracksDbResult.Concat(genre.Tracks);
                            }
                            initialized = true;
                        }
                        break;
                }

                Mapper.Initialize(cfg => cfg.CreateMap<Track, TrackBLL>()
                .ForMember(trackbll => trackbll.AuthorName, src => src.MapFrom(track => track.Author.AuthorName))
                 .ForMember(trackbll => trackbll.TrackRateAverage, src =>
                  src.MapFrom(track => track.TrackRates.Count() == 0 ? 0 : Math.Round(track.TrackRates
                  .Sum(rate => rate.TrackRateValue) / (double)track.TrackRates.Count(), MidpointRounding.AwayFromZero)
                  )));
                           
                    return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBLL>>(tracksDbResult).ToList();
         
            }
        }

    }
}


