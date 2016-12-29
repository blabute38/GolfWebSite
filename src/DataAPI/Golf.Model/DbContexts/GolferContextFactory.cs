using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Golf.Model.DbContexts
{
    public class GolferContextFactory : IDbContextFactory<GolferContext>
    {
        public GolferContext Create()
        {
            var builder = new DbContextOptionsBuilder<GolferContext>();
            builder.UseSqlServer(@"Data Source=mssql4.gear.host;Initial Catalog=golfingmodel;Integrated Security=False;User Id=golfingmodel;Password=Fe1m?7j_UhvR");
            return new GolferContext(builder.Options);
        }

        public GolferContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<GolferContext>();
            builder.UseSqlServer(@"Data Source=mssql4.gear.host;Initial Catalog=golfingmodel;Integrated Security=False;User Id=golfingmodel;Password=Fe1m?7j_UhvR");
            return new GolferContext(builder.Options);
        }
    }
}
