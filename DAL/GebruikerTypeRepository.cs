using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GebruikerTypeRepository : IGebruikerTypeRepository
    {
        private readonly DataContext _context;

        public GebruikerTypeRepository(DataContext context)
        {
            _context = context;
        }

        public GebruikerType FindById(int id)
        {
            return _context.GebruikerTypes.Where(g => g.Id == id).Single();
        }

        public List<GebruikerType> GetGebruikerTypes()
        {
            return _context.GebruikerTypes.ToList();
        }
    }
}
