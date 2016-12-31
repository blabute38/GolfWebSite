namespace Golf.Model.Migrations
{
    using DbContexts;

    internal sealed class GolferContextConfiguration : BaseContextConfiguration<GolferContext>
    {
        public GolferContextConfiguration() : base()
        {
        }

        protected override void Seed(GolferContext context)
        {
            //context.Golfers.Add(new Golfer()
            //{
            //    FirstName = "Brysen",
            //    LastName = "LaBute",
            //    Birthdate = new DateTime(1992, 09, 10),
            //    Class = Class.Amateur
            //});
        }
    }
}
