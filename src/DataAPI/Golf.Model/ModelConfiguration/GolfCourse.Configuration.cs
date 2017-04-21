using Golf.Model.Models;

namespace Golf.Model.ModelConfiguration
{
    public class GolfCourseConfiguration : BaseConfiguration<GolfCourse, int>
    {
        public GolfCourseConfiguration()
        {
            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
