namespace Golf.Model.Migrations
{
    using DbContexts;

    internal sealed class GolfCourseContextConfiguration : BaseContextConfiguration<GolfCourseContext>
    {
        public GolfCourseContextConfiguration() : base()
        {
        }

        protected override void Seed(GolfCourseContext context)
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
