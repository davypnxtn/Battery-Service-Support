using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Utilities;

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

        public RelatieIndexViewModel GetRelaties(string name, string address, int? pageNumber)
        {
            int pageSize = 2;
            var relatieIndexVM = new RelatieIndexViewModel();

            if (!string.IsNullOrEmpty(name))
            {
                var relatiesByName = repository.FindByNaam(name);

                if (relatiesByName.Count() != 0)
                {
                    relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relatiesByName, pageNumber ?? 1, pageSize);
                }
                else
                {
                    var relatiesByGivenName = repository.FindByRoepnaam(name);

                    relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relatiesByGivenName, pageNumber ?? 1, pageSize);
                }
            }
            else if (!string.IsNullOrEmpty(address))
            {
                var relatiesByAdres = repository.FindByAdres(address);

                if (relatiesByAdres.Count() != 0)
                {
                    relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relatiesByAdres, pageNumber ?? 1, pageSize);
                }
                else
                {
                    var leveradressen = leveradresRepository.FindByAdres(address);
                    var relatiesByLeveradres = new List<Relatie>();

                    foreach (var item in leveradressen)
                    {
                        relatiesByLeveradres.Add(item.Relatie);
                    }

                    relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relatiesByLeveradres, pageNumber ?? 1, pageSize);
                }
            }
            else
            {
                var relaties = repository.GetRelaties();

                relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relaties, pageNumber ?? 1, pageSize);
            }

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

        // ----- Zoek relatie op adres of leveradres -----
        //public RelatieIndexViewModel FindByAdres(string adres, int? pageNumber)
        //{
        //    var pageSize = 1;

        //    var relatieIndexVM = new RelatieIndexViewModel();

        //    if (!string.IsNullOrEmpty(adres))
        //    {
        //        var relaties = repository.FindByAdres(adres);

        //        relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relaties, pageNumber ?? 1, pageSize);

        //        if (relatieIndexVM.Relaties.Count == 0)
        //        {
        //            var leveradressen = leveradresRepository.FindByAdres(adres);
        //            var relatiesByLeveradres = new List<Relatie>();

        //            foreach (var item in leveradressen)
        //            {
        //                relatiesByLeveradres.Add(item.Relatie);
        //            }

        //            relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relatiesByLeveradres, pageNumber ?? 1, pageSize);
        //        }
        //    }
        //    else
        //    {
        //        relatieIndexVM = GetRelaties("", pageNumber);
        //    }

        //    return relatieIndexVM;
        //}

        public Relatie FindById(int id)
        {
            return repository.FindById(id);
        }

        // ----- Zoek relatie op naam of roepnaam -----
        //public RelatieIndexViewModel FindByNaam(string naam, int? pageNumber)
        //{
        //    int pageSize = 1;

        //    var relatieIndexVM = new RelatieIndexViewModel();
            
        //        if (!string.IsNullOrEmpty(naam))
        //        {
        //            var relatiesByName = repository.FindByNaam(naam);

        //            relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relatiesByName, pageNumber ?? 1, pageSize);

        //            if (relatieIndexVM.Relaties.Count == 0)
        //            {
        //                var relaties = repository.FindByRoepnaam(naam);

        //                relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relaties, pageNumber ?? 1, pageSize);
        //        }
        //        }
        //        else
        //        {
        //            relatieIndexVM = GetRelaties("", pageNumber);
        //        }
            
        //    return relatieIndexVM;
        //}

    }
}
