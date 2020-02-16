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

        public LeveradresService(ILeveradresRepository _repository, IRelatieRepository _relatieRepository)
        {
            repository = _repository;
            relatieRepository = _relatieRepository;
        }

        public LeveradresIndexViewModel CreateLeveradresIndexViewModel(int id)
        {
            var leveradresIndexVM = new LeveradresIndexViewModel
            {
                Leveradressen = FindByKlantId(id),
                Relatie = relatieRepository.FindById(id)
            };
            return leveradresIndexVM;
        }

        public Leveradres FindByAdres(string adres)
        {
            return repository.FindByAdres(adres);
        }

        public List<Leveradres> FindByKlantId(int id)
        {
            return repository.FindByKlantId(id);
        }
    }
}
