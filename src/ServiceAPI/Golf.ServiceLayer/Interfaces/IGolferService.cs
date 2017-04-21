using Golf.Model.Models;

namespace Golf.ServiceLayer.Interfaces
{
    public interface IGolferService : IEntityService<Golfer>
    {
        Golfer GetById(int id);
    }
}
