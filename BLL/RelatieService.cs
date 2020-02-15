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

        public RelatieService(IRelatieRepository _repository)
        {
            repository = _repository;
        }

        public RelatieDetailViewModel CreateRelatieDetailViewModel(int id)
        {
            var relatieDetailVM = new RelatieDetailViewModel
            {
                Relatie = FindById(id)
            };
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
