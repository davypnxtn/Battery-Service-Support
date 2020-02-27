using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL
{
    public class RelatieService : IRelatieService
    {
        private readonly IRelatieRepository repository;
        private readonly ILeveradresRepository leveradresRepository;
        private readonly IInstallatieRepository installatieRepository;

        public RelatieService(IRelatieRepository _repository, ILeveradresRepository _leveradresRepository, IInstallatieRepository _installatieRepository)
        {
            repository = _repository;
            leveradresRepository = _leveradresRepository;
            installatieRepository = _installatieRepository;
        }

        public RelatieDetailViewModel CreateRelatieDetailViewModel(int id)
        {
            var relatieDetailVM = new RelatieDetailViewModel
            {
                Relatie = FindById(id),
                Leveradressen = leveradresRepository.FindByKlantId(id)
            };
            //if (relatieDetailVM.Leveradressen.Count == 0)
            //{
            //    Leveradres leveradres = new Leveradres()
            //    {
            //        Naam = relatieDetailVM.Relatie.Naam,
            //        Adres = relatieDetailVM.Relatie.Adres,
            //        Gemeente = gemeenteRepository.FindById(relatieDetailVM.Relatie.GemeenteId)
            //    };
            //    relatieDetailVM.Leveradressen.Add(leveradres);
            //}
            return relatieDetailVM;
        }

        public RelatieIndexViewModel CreateRelatieIndexViewModel()
        {
            var relatieIndexVM = new RelatieIndexViewModel
            {
                Relaties = GetRelaties()
            };
            return relatieIndexVM;
        }

        public RelatieInstallatieViewModel CreateRelatieInstallatieViewModel(int id)
        {
            var relatieInstallatieVM = new RelatieInstallatieViewModel()
            {
                Relatie = FindById(id),
                Installaties = installatieRepository.FindByRelatieId(id)
            };
            return (relatieInstallatieVM);
        }

        public Relatie FindByAdres(string adres)
        {
            return repository.FindByAdres(adres);
        }

        public Relatie FindById(int id)
        {
            return repository.FindById(id);
        }

        public Relatie FindByNaam(string naam)
        {
            return repository.FindByNaam(naam);
        }

        public List<Relatie> GetRelaties()
        {
            return repository.GetRelaties();
        }
    }
}
