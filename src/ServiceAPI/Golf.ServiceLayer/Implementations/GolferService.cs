using Golf.Model;
using Golf.Repository.Interfaces;
using Golf.ServiceLayer.Interfaces;

namespace Golf.ServiceLayer.Implementations
{
    public class GolferService : EntityService<Golfer>, IGolferService
    {
        IUnitOfWork _unitOfWork;
        IGolferRepository _golferRepository;

        public GolferService(IUnitOfWork unitOfWork, IGolferRepository golferRepository)
          : base(unitOfWork, golferRepository)
        {
            _unitOfWork = unitOfWork;
            _golferRepository = golferRepository;
        }

        public Golfer GetById(int Id)
        {
            return _golferRepository.GetById(Id);
        }
    }
}