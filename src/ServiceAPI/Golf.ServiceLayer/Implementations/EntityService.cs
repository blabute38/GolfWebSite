using Golf.Model.Models;
using Golf.Repository.Interfaces;
using Golf.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Golf.ServiceLayer.Implementations
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual HttpResponseMessage Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public virtual HttpResponseMessage Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
            _unitOfWork.Commit();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public virtual HttpResponseMessage Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
