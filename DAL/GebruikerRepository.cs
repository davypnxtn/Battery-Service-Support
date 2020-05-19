using DAL.Data;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly DataContext _context;
        public GebruikerRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Opvragen gebruiker op xjoGebruikerCode -----
        public Gebruiker FindByCode(string code)
        {
            return _context.Gebruikers.Where(g => g.XjoGebruikerCode == code).Single();
        }

        // ----- Opvragen gebruiker op gebruikerId -----
        public Gebruiker FindById(int id)
        {
            return _context.Gebruikers.Where(g => g.Id == id).Single();
        }

        // ----- Opvragen gebruiker op gebruikersnaam -----
        public Gebruiker FindByNaam(string naam)
        {
            return _context.Gebruikers.Where(g => g.Naam == naam).Single();
        }

        // ----- Opvragen alle gebruikers -----
        public List<Gebruiker> GetGebruikers()
        {
            return _context.Gebruikers.ToList();
        }
    }
}
