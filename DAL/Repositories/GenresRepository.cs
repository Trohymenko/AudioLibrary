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
    class GenresRepository : IRepository<Genre>
    {
        private TracksContext db;
        public GenresRepository(TracksContext context)
        {
            this.db = context;
        }
        public IEnumerable<Genre> GetAll(Func<Genre, bool> predicate)
        {
            return db.Genres.Where(predicate);
        }

        public Genre Get(int id)
        {
            return db.Genres.Find(id);
        }

        public void Create(Genre genre)
        {
            db.Genres.Add(genre);
            db.SaveChanges();
        }

        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Genre Find(Func<Genre, Boolean> predicate)
        {
            return db.Genres.Find(predicate);
        }

        public void Delete(int id)
        {
            Genre product = db.Genres.Find(id);
            if (product != null)
                db.Genres.Remove(product);
            db.SaveChanges();
        }
    }
}
