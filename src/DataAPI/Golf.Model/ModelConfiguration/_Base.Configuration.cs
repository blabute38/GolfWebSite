using Golf.Model.Models;
using System;
using System.Data.Entity.ModelConfiguration;

namespace Golf.Model.ModelConfiguration
{
    public class BaseConfiguration<S, T> : EntityTypeConfiguration<S>
        where S : Entity<T>
    {
        public BaseConfiguration()
        {
            HasKey(x => x.Id);
        }
    }
}
