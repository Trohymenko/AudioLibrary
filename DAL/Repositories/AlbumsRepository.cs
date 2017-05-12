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
    class AlbumsRepository : IRepository<Album>
    {
        private TracksContext db;
        public AlbumsRepository(TracksContext context)
        {
            this.db = context;
        }
        public IEnumerable<Album> GetAll()
        {
            return db.Albums;
        }

        public Album Get(int id)
        {
            return db.Albums.Find(id);
        }

        public void Create(Album album)
        {
            db.Albums.Add(album);
            db.SaveChanges();
        }

        public void Update(Album album)
        {
            db.Entry(album).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Album> Find(Func<Album, Boolean> predicate)
        {
            return db.Albums.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Album album = db.Albums.Find(id);
            if (album != null)
                db.Albums.Remove(album);
            db.SaveChanges();
        }
    }
}
