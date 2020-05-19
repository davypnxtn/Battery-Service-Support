using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using ViewModel;

namespace BLL
{
    public class InstallatieService : IInstallatieService
    {
        private readonly IInstallatieRepository repository;
        private readonly IBatterijRepository batterijRepository;

        public InstallatieService(IInstallatieRepository _repository, IBatterijRepository _batterijRepository)
        {
            repository = _repository;
            batterijRepository = _batterijRepository;
        }

        // ----- Aanmaken InstallatieDetailViewModel voor Detail view van InstallatieController -----
        public InstallatieDetailViewModel CreateInstallatieDetailViewModel(int id)
        {
            var installatieDetailVM = new InstallatieDetailViewModel
            {
                Installatie = FindById(id),
                Batterijen = batterijRepository.FindActiveByInstallatieId(id)
            };
            return installatieDetailVM;
        }

        // ----- Opvragen installatie op installatieId -----
        public Installatie FindById(int id)
        {
            return repository.FindById(id);
        }

        // ----- Opvragen installaties op leveradresId -----
        public List<Installatie> FindByLeveradresId(int id)
        {
            return repository.FindByLeveradresId(id);
        }

        // ----- Opvragen installaties op relatieId -----
        public List<Installatie> FindByRelatieId(int id)
        {
            return repository.FindByRelatieId(id);
        }
    }
}
