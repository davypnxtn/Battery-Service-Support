using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using ViewModel;

namespace BLL
{
    public class LeveradresService : ILeveradresService
    {
        private readonly ILeveradresRepository repository;
        private readonly IInstallatieRepository installatieRepository;
    
        public LeveradresService(ILeveradresRepository _repository, IInstallatieRepository _installatieRepository)
        {
            repository = _repository;
            installatieRepository = _installatieRepository;
        }

        // ----- Aanmaken LeveradresDetailViewModel voor Detail view van LeveradresController -----
        public LeveradresDetailViewModel CreateLeveradresDetailViewModel(int id)
        {
            var leveradresDetailVM = new LeveradresDetailViewModel
            {
                Leveradres = FindById(id),
                Installaties = installatieRepository.FindByLeveradresId(id)
            };
            return leveradresDetailVM;
        }


        // ----- Opvragen leveradressen op adres -----
        public List<Leveradres> FindByAdres(string adres)
        {
            return repository.FindByAdres(adres);
        }

        // ----- Opvragen leveradressen op leveradresId -----
        public Leveradres FindById(int id)
        {
            return repository.FindById(id);
        }

        // ----- Opvragen leveradressen op relatieId -----
        public List<Leveradres> FindByRelatieId(int id)
        {
            return repository.FindByRelatieId(id);
        }
    }
}
