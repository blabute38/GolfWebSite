using Golf.Model.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace Golf.ServiceLayer.Interfaces
{
    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        HttpResponseMessage Create(T entity);
        HttpResponseMessage Delete(T entity);
        IEnumerable<T> GetAll();
        HttpResponseMessage Update(T entity);
    }
}
