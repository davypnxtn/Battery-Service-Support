using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LandRepository : ILandRepository
    {
        private readonly DataContext _context;

        public LandRepository(DataContext context)
        {
            _context = context;
        }

        public Land FindById(int id)
        {
            return _context.Landen.Where(l => l.Id == id).Single();
        }
    }
}
