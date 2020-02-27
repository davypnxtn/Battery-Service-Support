using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class InstallatieService : IInstallatieService
    {
        private readonly IInstallatieRepository repository;

        public InstallatieService(IInstallatieRepository _repository)
        {
            repository = _repository;
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
