namespace Golf.Model.Migrations
{
    using DbContexts;
    using System.Data.Entity.Migrations;

    internal class BaseContextConfiguration<T> : DbMigrationsConfiguration<T> where T: BaseContext
    {
        public BaseContextConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}
