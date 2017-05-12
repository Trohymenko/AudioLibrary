using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL
{
    public class TracksUnitOfWork : ITracksUnitOfWork
    {
        private TracksContext db;

        private TracksRepository tracksRepository;
        private AlbumsRepository albumsRepository;
        private AuthorsRepository authorsRepository;
        private GenresRepository genresRepository;

        public TracksUnitOfWork(string connectionString)
        {
            db = new TracksContext(connectionString);

        }
        public IRepository<Track> Tracks
        {
            get
            {
                if (tracksRepository == null)
                    tracksRepository = new TracksRepository(db);
                return tracksRepository;
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                if (albumsRepository == null)
                    albumsRepository = new AlbumsRepository(db);
                return albumsRepository;
            }
        }
        public IRepository<Genre> Genres
        {
            get
            {
                if (genresRepository == null)
                    genresRepository = new GenresRepository(db);
                return genresRepository;
            }
        }
        public IRepository<Author> Authors
        {
            get
            {
                if (authorsRepository == null)
                    authorsRepository = new AuthorsRepository(db);
                return authorsRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
