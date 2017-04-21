using Golf.Model.Models;
using Golf.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Golf.Repository.Implementations
{
    public abstract class GenericRepository<S, T> : IGenericRepository<S>
      where S : Entity<T>
      where T : IComparable
    {
        protected DbContext _dbContext;
        protected readonly IDbSet<S> _dbSet;

        public GenericRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<S>();
        }

        public virtual IEnumerable<S> GetAll()
        {
            return _dbSet.AsEnumerable<S>();
        }

        public IEnumerable<S> FindBy(System.Linq.Expressions.Expression<Func<S, bool>> predicate)
        {
            IEnumerable<S> query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual S Add(S entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual S Delete(S entity)
        {
            return _dbSet.Remove(entity);
        }

        public virtual void Edit(S entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        // had to use CompareTo rather than == because of generic id attribute
        public S GetById(T id)
        {
            return _dbSet.Where(x => x.Id.CompareTo(id) == 0).FirstOrDefault();
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
