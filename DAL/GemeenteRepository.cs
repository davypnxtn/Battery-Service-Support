using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GemeenteRepository : IGemeenteRepository
    {
        private readonly DataContext _context;

        public GemeenteRepository(DataContext context)
        {
            _context = context;
        }

        public Gemeente FindById(int id)
        {
            return _context.Gemeentes.Where(g => g.Id == id).Single();
        }
    }
}
