using Golf.Model;
using Golf.Repository.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Golf.Repository.Implementations
{
    public class GolferRepository : GenericRepository<Golfer>, IGolferRepository
    {
        public GolferRepository(DbContext context)
           : base(context)
        {

        }

        public override IEnumerable<Golfer> GetAll()
        {
            return _dbContext.Set<Golfer>().AsEnumerable();
        }

        public Golfer GetById(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
