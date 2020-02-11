using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ModDatumRepository : IModDatumRepository
    {
        private readonly DataContext _context;

        public ModDatumRepository(DataContext context)
        {
            _context = context;
        }

        public ModDatum GetModDatum()
        {
            return _context.ModData.Last();
        }
    }
}
