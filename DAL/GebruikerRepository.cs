using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly DataContext _context;
        public GebruikerRepository(DataContext context)
        {
            _context = context;
        }

        public Gebruiker FindByCode(string code)
        {
            return _context.Gebruikers.Where(g => g.XjoGebruikerCode == code).Single();
        }

        public Gebruiker FindById(int id)
        {
            return _context.Gebruikers.Where(g => g.Id == id).Single();
        }

        public Gebruiker FindByNaam(string naam)
        {
            return _context.Gebruikers.Where(g => g.Naam == naam).Single();
        }

        public List<Gebruiker> GetGebruikers()
        {
            return _context.Gebruikers.ToList();
        }
    }
}
