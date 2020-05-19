using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class GebruikerService : IGebruikerService
    {
        private readonly IGebruikerRepository repository;

        public GebruikerService(IGebruikerRepository _repository)
        {
            repository = _repository;
        }

        // ----- Opvragen gebruiker op xjoGebruikerCode -----
        public Gebruiker FindByCode(string code)
        {
            return repository.FindByCode(code);
        }

        // ----- Opvragen gebruiker op gebruikerId -----
        public Gebruiker FindById(int id)
        {
            return repository.FindById(id);
        }

        // ----- Opvragen gebruiker op gebruikersnaam -----
        public Gebruiker FindByNaam(string naam)
        {
            return repository.FindByNaam(naam);
        }

        // ----- Opvragen alle gebruikers -----
        public List<Gebruiker> GetGebruikers()
        {
            return repository.GetGebruikers();
        }
    }
}
