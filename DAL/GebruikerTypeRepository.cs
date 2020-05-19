using DAL.Data;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class GebruikerTypeRepository : IGebruikerTypeRepository
    {
        private readonly DataContext _context;

        public GebruikerTypeRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Opvragen gebruikertype op gebruikerTypeId -----
        public GebruikerType FindById(int id)
        {
            return _context.GebruikerTypes.Where(g => g.Id == id).Single();
        }

        // ----- Opvragen alle gebruikertypes -----
        public List<GebruikerType> GetGebruikerTypes()
        {
            return _context.GebruikerTypes.ToList();
        }
    }
}
