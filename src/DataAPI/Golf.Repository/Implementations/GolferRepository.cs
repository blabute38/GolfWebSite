using Golf.Model.Models;
using Golf.Repository.Interfaces;
using System.Data.Entity;

namespace Golf.Repository.Implementations
{
    public class GolferRepository : GenericRepository<Golfer, int>, IGolferRepository
    {
        public GolferRepository(DbContext context)
           : base(context)
        {

        }
        //public override IEnumerable<Golfer> GetAll()
        //{
        //    return _dbContext.Set<Golfer>().AsEnumerable();
        //}

        //public Golfer GetById(int id)
        //{
        //    return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        //}
    }
}
