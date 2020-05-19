using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class LandService : ILandService
    {
        private readonly ILandRepository repository;

        public LandService(ILandRepository _repository)
        {
            repository = _repository;
        }

        // ----- Opvragen land op landId -----
        public Land FindById(int id)
        {
            return repository.FindById(id);
        }
    }
}
