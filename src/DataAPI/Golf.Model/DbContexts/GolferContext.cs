using System.Data.Entity;
using Golf.Model.Migrations;
using Golf.Model.Models;
using Golf.Model.ModelConfiguration;

namespace Golf.Model.DbContexts
{
    public class GolferContext : BaseContext
    {
        public GolferContext() : base()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<GolferContext, GolferContextConfiguration>(databaseName));
        }

        public DbSet<Golfer> Golfers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GolferConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
