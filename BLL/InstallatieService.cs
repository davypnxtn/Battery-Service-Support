using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
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

        public InstallatieDetailViewModel CreateInstallatieDetailViewModel(int id)
        {
            //Installatie installatie = FindById(id);
            var installatieDetailVM = new InstallatieDetailViewModel
            {
                Installatie = FindById(id),
                Batterijen = batterijRepository.FindActiveByInstallatieId(id)
            };
            return installatieDetailVM;
        }

        public Installatie FindById(int id)
        {
            return repository.FindById(id);
        }

        public List<Installatie> FindByLeveradresId(int id)
        {
            return repository.FindByLeveradresId(id);
        }

        public List<Installatie> FindByRelatieId(int id)
        {
            return repository.FindByRelatieId(id);
        }
    }
}
