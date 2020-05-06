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
                Leveradressen = leveradresRepository.FindByRelatieId(id)
            };
            return relatieDetailVM;
        }

        public RelatieIndexViewModel GetRelaties()
        {
            var relatieIndexVM = new RelatieIndexViewModel
            {
                Relaties = repository.GetRelaties()
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

        public RelatieIndexViewModel FindByAdres(string adres)
        {
            var relatieIndexVM = new RelatieIndexViewModel();

            if (!string.IsNullOrEmpty(adres))
            {
                relatieIndexVM.Relaties = repository.FindByAdres(adres);
                if (relatieIndexVM.Relaties.Count == 0)
                {
                    var leveradressen = leveradresRepository.FindByAdres(adres);
                    foreach (var item in leveradressen)
                    {
                        relatieIndexVM.Relaties.Add(item.Relatie);
                    }
                }
            }
            else
            {
                relatieIndexVM = GetRelaties();
            }

            return relatieIndexVM;
        }

        public Relatie FindById(int id)
        {
            return repository.FindById(id);
        }

        public RelatieIndexViewModel FindByNaam(string naam)
        {
            var relatieIndexVM = new RelatieIndexViewModel();
            
                if (!string.IsNullOrEmpty(naam))
                {
                    relatieIndexVM.Relaties = repository.FindByNaam(naam);
                    if (relatieIndexVM.Relaties.Count == 0)
                    {
                        relatieIndexVM.Relaties = repository.FindByRoepnaam(naam);
                    }
                }
                else
                {
                    relatieIndexVM = GetRelaties();
                }
            
            return relatieIndexVM;
        }

    }
}
