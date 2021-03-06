﻿using Golf.Model.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace Golf.ServiceLayer.Interfaces
{
    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}
