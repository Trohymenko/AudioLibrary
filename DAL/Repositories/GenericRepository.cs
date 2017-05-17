using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;
using DAL.Interfaces;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal TracksContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(TracksContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;
            
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public TEntity Find(Func<TEntity, Boolean> predicate)
        {
            return dbSet.Find(predicate);
        }

        public void Delete(int id)
        {
            TEntity entity = dbSet.Find(id);
            if (entity != null)
                dbSet.Remove(entity);
            context.SaveChanges();
        }

    }
}
