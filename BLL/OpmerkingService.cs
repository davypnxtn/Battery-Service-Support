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

        public void Add(string notitie, int batterijId)
        {
            Opmerking opmerking = new Opmerking()
            {
                Notitie = notitie,
                BatterijId = batterijId,
                GebruikerId = 1,
                ModDatum = DateTime.Now
            };
            repository.Add(opmerking);
        }

        public List<Opmerking> FindByBatterijId(int? id)
        {
            return repository.FindByBatterijId(id);
        }
    }
}
