using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class LeveradresService : ILeveradresService
    {
        private readonly ILeveradresRepository repository;

        public LeveradresService(ILeveradresRepository _repository)
        {
            repository = _repository;
        }

        public Leveradres FindByAdres(string adres)
        {
            return repository.FindByAdres(adres);
        }

        public List<Leveradres> FindByKlantId(int id)
        {
            return repository.FindByKlantId(id);
        }
    }
}
