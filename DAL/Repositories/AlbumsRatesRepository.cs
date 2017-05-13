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
    public  class AlbumsRatesRepository : IRepository<AlbumRate>
    {
        private TracksContext db;
        public AlbumsRatesRepository(TracksContext context)
        {
            this.db = context;
        }
        public IEnumerable<AlbumRate> GetAll(Func<AlbumRate, bool> predicate)
        {
            return db.AlbumsRates.Where(predicate);
        }

        public AlbumRate Get(int id)
        {
            return db.AlbumsRates.Find(id);
        }

        public void Create(AlbumRate album)
        {
            db.AlbumsRates.Add(album);
            db.SaveChanges();
        }

        public void Update(AlbumRate album)
        {
            db.Entry(album).State = EntityState.Modified;
            db.SaveChanges();
        }

        public AlbumRate Find(Func<AlbumRate, Boolean> predicate)
        {
            return db.AlbumsRates.Find(predicate);
        }

        public void Delete(int id)
        {
            AlbumRate album = db.AlbumsRates.Find(id);
            if (album != null)
                db.AlbumsRates.Remove(album);
            db.SaveChanges();
        }
    }
}
