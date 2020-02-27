using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL
{
    public class LeveradresService : ILeveradresService
    {
        private readonly ILeveradresRepository repository;
        private readonly IRelatieRepository relatieRepository;
        private readonly IInstallatieRepository installatieRepository;
    
        public LeveradresService(ILeveradresRepository _repository, IRelatieRepository _relatieRepository, IInstallatieRepository _installatieRepository)
        {
            repository = _repository;
            relatieRepository = _relatieRepository;
            installatieRepository = _installatieRepository;
        }

        public LeveradresDetailViewModel CreateLeveradresDetailViewModel(int id)
        {
            var leveradresDetailVM = new LeveradresDetailViewModel
            {
                Leveradres = FindById(id),
                Installaties = installatieRepository.FindByLeveradresId(id)
            };
            return leveradresDetailVM;
        }

        //public LeveradresIndexViewModel CreateLeveradresIndexViewModel(int id)
        //{
        //    var leveradresIndexVM = new LeveradresIndexViewModel
        //    {
        //        Leveradressen = FindByKlantId(id),
        //        Relatie = relatieRepository.FindById(id)
        //    };
        //    return leveradresIndexVM;
        //}

        public Leveradres FindByAdres(string adres)
        {
            return repository.FindByAdres(adres);
        }

        public Leveradres FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<Leveradres> FindByKlantId(int id)
        {
            return repository.FindByKlantId(id);
        }
    }
}
