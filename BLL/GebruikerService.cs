using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class GebruikerService : IGebruikerService
    {
        private readonly IGebruikerRepository repository;

        public GebruikerService(IGebruikerRepository _repository)
        {
            repository = _repository;
        }

        public Gebruiker FindByCode(string code)
        {
            return repository.FindByCode(code);
        }

        public Gebruiker FindById(int id)
        {
            return repository.FindById(id);
        }

        public Gebruiker FindByNaam(string naam)
        {
            return repository.FindByNaam(naam);
        }

        public List<Gebruiker> GetGebruikers()
        {
            return repository.GetGebruikers();
        }
    }
}
