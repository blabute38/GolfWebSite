using Golf.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Golf.Model.ModelConfiguration
{
    public class AuditableEntityConfiguration<T> : EntityTypeConfiguration<AuditableEntity<T>>
    {
        public AuditableEntityConfiguration()
        {
            Property(x => x.CreatedBy)
                .HasMaxLength(256);

            Property(x => x.UpdatedBy)
                .HasMaxLength(256);
        }
    }
}
