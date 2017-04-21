using Golf.Model.Models;

namespace Golf.Model.ModelConfiguration
{
    public class GolferConfiguration : BaseConfiguration<Golfer, int>
    {
        public GolferConfiguration()
        {
            Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
