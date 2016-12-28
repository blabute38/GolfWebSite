using Golf.Model;
using System.Data.Entity.ModelConfiguration;

namespace Golf.Model.Mapping
{
    public class GolferConfiguration : EntityTypeConfiguration<Golfer>
    {
        public GolferConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
