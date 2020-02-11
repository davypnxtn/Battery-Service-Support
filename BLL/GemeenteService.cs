using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class GemeenteService : IGemeenteService
    {
        private readonly IGemeenteRepository repository;

        public GemeenteService(IGemeenteRepository _repository)
        {
            repository = _repository;
        }

        public Gemeente FindById(int id)
        {
            return repository.FindById(id);
        }
    }
}
