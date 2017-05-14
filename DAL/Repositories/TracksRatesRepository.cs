using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Entities;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class TracksRatesRepository : IRepository<TrackRate>
    {
        private TracksContext db;
        public TracksRatesRepository(TracksContext context)
        {
            this.db = context;
        }
        public IEnumerable<TrackRate> GetAll(Func<TrackRate, bool> predicate)
        {
            return db.TracksRates.Where(predicate);
        }

        public TrackRate Get(int id)
        {
            return db.TracksRates.Find(id);
        }

        public void Create(TrackRate trackRate)
        {
            db.TracksRates.Add(trackRate);
            db.SaveChanges();
        }

        public void Update(TrackRate track)
        {
            db.Entry(track).State = EntityState.Modified;
            db.SaveChanges();
        }

        public TrackRate Find(Func<TrackRate, Boolean> predicate)
        {
            return db.TracksRates.Find(predicate);
        }

        public void Delete(int id)
        {
            TrackRate track = db.TracksRates.Find(id);
            if (track != null)
                db.TracksRates.Remove(track);
            db.SaveChanges();
        }
    }
}
