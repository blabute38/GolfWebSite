using Golf.Model.Interfaces;
using System;

namespace Golf.Model.Models
{
    public abstract class BaseEntity
    {
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
