using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class OpmerkingService : IOpmerkingService
    {
        private readonly IOpmerkingRepository repository;

        public OpmerkingService(IOpmerkingRepository _repository)
        {
            repository = _repository;
        }

        public List<Opmerking> FindByInstallatieId(int id)
        {
            return repository.FindByBatterijId(id);
        }
    }
}
