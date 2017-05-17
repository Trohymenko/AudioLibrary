using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Interfaces;
using DAL.Entities;

namespace DAL
{
    public class RatesUnitOfWork : IRatesUnitOfWork
    {
        private TracksContext context;

        private GenericRepository<TrackRate> trackRateRepository;
        private GenericRepository<AlbumRate> albumRateRepository;

        public RatesUnitOfWork(string connectionString)
        {
            context = new TracksContext(connectionString);

        }
        public IRepository<TrackRate> TracksRates
        {
            get
            {
                if (trackRateRepository == null)
                    trackRateRepository = new GenericRepository<TrackRate>(context);
                return trackRateRepository;
            }
        }

        public IRepository<AlbumRate> AlbumsRates
        {
            get
            {
                if (albumRateRepository == null)
                    albumRateRepository = new GenericRepository<AlbumRate>(context);
                return albumRateRepository;
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
