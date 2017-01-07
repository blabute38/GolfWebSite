using Golf.Model.Models;

namespace Golf.Repository.Interfaces
{
    public interface IGolferRepository : IGenericRepository<Golfer>
    {
        Golfer GetById(int id);
    }
}
