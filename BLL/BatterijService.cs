using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL
{
    public class BatterijService : IBatterijService
    {
        private readonly IBatterijRepository repository;
        private readonly IOpmerkingRepository opmerkingRepository;
        private readonly IGebruikerRepository gebruikerRepository;

        public BatterijService(IBatterijRepository _repository, IOpmerkingRepository _opmerkingRepository, IGebruikerRepository _gebruikerRepository)
        {
            repository = _repository;
            opmerkingRepository = _opmerkingRepository;
            gebruikerRepository = _gebruikerRepository;
        }

        public BatterijDetailViewModel CreateBatterijDetailViewModel(int id)
        {
            Batterij batterij = FindById(id);
            var batterijDetailVM = new BatterijDetailViewModel
            {
                Batterij = batterij,
                Opmerkingen = opmerkingRepository.FindByBatterijId(id),
                Gebruiker = gebruikerRepository.FindById(batterij.GebruikerId),
                RelatieId = batterij.Installatie.RelatieId,
                LeveradresId = batterij.Installatie.LeveradresId,
                InstallatieId = batterij.InstallatieId
            };
            return batterijDetailVM;
        }

        public Batterij FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<Batterij> FindByInstallatieId(int id)
        {
            return repository.FindByInstallatieId(id);
        }
    }
}
