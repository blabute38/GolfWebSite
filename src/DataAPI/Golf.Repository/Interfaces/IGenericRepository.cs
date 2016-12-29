using Golf.Model.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Golf.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        EntityEntry<T> Add(T entity);
        EntityEntry<T> Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
