using BLL.Interfaces;
using DAL.Interfaces;
using Model;

namespace BLL
{
    public class GemeenteService : IGemeenteService
    {
        private readonly IGemeenteRepository repository;

        public GemeenteService(IGemeenteRepository _repository)
        {
            repository = _repository;
        }

        // ----- Opvragen gemeente op gemeenteId -----
        public Gemeente FindById(int id)
        {
            return repository.FindById(id);
        }
    }
}
