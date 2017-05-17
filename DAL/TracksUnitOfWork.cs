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
        private TracksContext context;
       
        private GenericRepository<Track> tracksRepository;
        private GenericRepository<Album> albumsRepository;
        private GenericRepository<Author> authorsRepository;
        private GenericRepository<Genre> genresRepository;

        public TracksUnitOfWork(string connectionString)
        {
            context = new TracksContext(connectionString);

        }
        public IRepository<Track> Tracks
        {
            get
            {
                if (tracksRepository == null)
                    tracksRepository = new GenericRepository<Track>(context);
                return tracksRepository;
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                if (albumsRepository == null)
                    albumsRepository = new GenericRepository<Album>(context);
                return albumsRepository;
            }
        }
        public IRepository<Genre> Genres
        {
            get
            {
                if (genresRepository == null)
                    genresRepository = new GenericRepository<Genre>(context);
                return genresRepository;
            }
        }
        public IRepository<Author> Authors
        {
            get
            {
                if (authorsRepository == null)
                    authorsRepository = new GenericRepository<Author>(context);
                return authorsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
