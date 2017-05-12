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
        public IEnumerable<Track> GetAll()
        {
            return db.Tracks.Where(x=> true);
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

        public IEnumerable<Track> Find(Func<Track, Boolean> predicate)
        {
            return db.Tracks.Where(predicate).ToList();
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
