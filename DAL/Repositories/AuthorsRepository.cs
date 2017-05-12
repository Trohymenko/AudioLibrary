﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class AuthorsRepository : IRepository<Author>
    {
        private TracksContext db;
        public AuthorsRepository(TracksContext context)
        {
            this.db = context;
        }
        public IEnumerable<Author> GetAll()
        {
            return db.Authors;
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public void Create(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public void Update(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Author> Find(Func<Author, Boolean> predicate)
        {
            return db.Authors.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Author product = db.Authors.Find(id);
            if (product != null)
                db.Authors.Remove(product);
            db.SaveChanges();
        }
    }
}