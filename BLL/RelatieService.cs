using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using System.Linq;
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

        // ----- Aanmaken RelatieDetailViewModel voor Detail view van RelatieController -----
        public RelatieDetailViewModel CreateRelatieDetailViewModel(int id)
        {
            var relatieDetailVM = new RelatieDetailViewModel
            {
                Relatie = FindById(id),
                Leveradressen = leveradresRepository.FindByRelatieId(id)
            };
            return relatieDetailVM;
        }

        // ----- Opvragen alle relaties met paginering en zoekfunctie op naam en adres  en toevoegen aan RelatieIndexViewModel-----
        // Voor Index view van RelatieController en ListCustomers view van ExportController
        public RelatieIndexViewModel GetRelaties(string name, string address, int? pageNumber)
        {
            int pageSize = 10;
            var relatieIndexVM = new RelatieIndexViewModel();

            // Als "name" niet null of leeg is dan wordt de lijst van Relaties in de viewmodel gefiltert op naam en roepnaam van relatie
            if (!string.IsNullOrEmpty(name))
            {
                var relatiesByName = repository.FindByNaam(name);
                var relatiesByGivenName = repository.FindByRoepnaam(name);

                relatiesByName.AddRange(relatiesByGivenName);
                relatiesByName = relatiesByName.OrderBy(r => r.XjoRelatieCode).Distinct().ToList();

                relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relatiesByName, pageNumber ?? 1, pageSize);
            }
            // Als "address" niet null of leeg is wordt de lijst van Relaties in de viewmodel gefiltert op adres en leveradres van relatie
            else if (!string.IsNullOrEmpty(address))
            {
                var relatiesByAddress = repository.FindByAdres(address);
                var leveradressen = leveradresRepository.FindByAdres(address);
                var relatiesByLeveradres = new List<Relatie>();

                    foreach (var item in leveradressen)
                    {
                        relatiesByLeveradres.Add(item.Relatie);
                    }

                relatiesByAddress.AddRange(relatiesByLeveradres);
                relatiesByAddress = relatiesByAddress.OrderBy(r => r.XjoRelatieCode).Distinct().ToList();

                relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relatiesByAddress, pageNumber ?? 1, pageSize);
            }
            // Zijn "name" en "address" beide leeg dan wordt de lijst van Relaties in de viewmodel opgevuld met alle relaties
            else
            {
                var relaties = repository.GetRelaties().OrderBy(r => r.XjoRelatieCode).ToList();

                relatieIndexVM.Relaties = PaginatedList<Relatie>.Create(relaties, pageNumber ?? 1, pageSize);
            }

            return relatieIndexVM;
        }

        // ----- Aanmaken RelatieInstallatie viewmodel voor Installatie view van RelatieController -----
        public RelatieInstallatieViewModel CreateRelatieInstallatieViewModel(int id)
        {
            var relatieInstallatieVM = new RelatieInstallatieViewModel()
            {
                Relatie = FindById(id),
                Installaties = installatieRepository.FindByRelatieId(id)
            };
            return (relatieInstallatieVM);
        }

        // ----- Opvragen relatie op relatieId -----
        public Relatie FindById(int id)
        {
            return repository.FindById(id);
        }
    }
}
