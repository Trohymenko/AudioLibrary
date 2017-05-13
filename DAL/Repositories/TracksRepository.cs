using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class TracksRepository : IRepository<Track>
    {
        private TracksContext db;
        public TracksRepository(TracksContext context)
        {
            this.db = context;
        }
        public IEnumerable<Track> GetAll(Func<Track,bool> predicate)
        {
            return db.Tracks.Where(predicate);
        }

        public Track Get(int id)
        {
            return db.Tracks.Find(id);
        }

        public void Create(Track track)
        {
            db.Tracks.Add(track);
            db.SaveChanges();
        }

        public void Update(Track track)
        {
            db.Entry(track).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Track Find(Func<Track, Boolean> predicate)
        {
            return db.Tracks.Find(predicate);
        }

        public void Delete(int id)
        {
            Track track = db.Tracks.Find(id);
            if (track != null)
                db.Tracks.Remove(track);
            db.SaveChanges();
        }
    }
}
