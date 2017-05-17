using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null);
        TEntity Get(int id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        TEntity Find(Func<TEntity, bool> predicate);

    }
}
