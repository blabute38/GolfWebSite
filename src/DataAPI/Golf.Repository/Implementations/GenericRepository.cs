using Golf.Model.Models;
using Golf.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Golf.Repository.Implementations
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
      where T : BaseEntity
    {
        protected DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbSet.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual EntityEntry<T> Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual EntityEntry<T> Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
