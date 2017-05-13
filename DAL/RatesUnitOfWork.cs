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
    class RatesUnitOfWork : IRatesUnitOfWork
    {
        private TracksContext db;

        private TracksRatesRepository trackRateRepository;
        private AlbumsRatesRepository albumRateRepository;

        public RatesUnitOfWork(string connectionString)
        {
            db = new TracksContext(connectionString);

        }
        public IRepository<TrackRate> TracksRates
        {
            get
            {
                if (trackRateRepository == null)
                    trackRateRepository = new TracksRatesRepository(db);
                return trackRateRepository;
            }
        }

        public IRepository<AlbumRate> AlbumsRates
        {
            get
            {
                if (albumRateRepository == null)
                    albumRateRepository = new AlbumsRatesRepository(db);
                return albumRateRepository;
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
