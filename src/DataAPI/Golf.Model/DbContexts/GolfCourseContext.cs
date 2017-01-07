using System.Data.Entity;
using Golf.Model.Migrations;
using Golf.Model.Models;
using Golf.Model.ModelConfiguration;

namespace Golf.Model.DbContexts
{
    public class GolfCourseContext : BaseContext
    {
        public GolfCourseContext() : base()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<GolfCourseContext, GolfCourseContextConfiguration>(databaseName));
        }

        public DbSet<GolfCourse> GolfCourses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GolfCourseConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
