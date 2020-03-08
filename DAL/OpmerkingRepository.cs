using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class OpmerkingRepository : IOpmerkingRepository
    {
        private readonly DataContext _context;

        public OpmerkingRepository(DataContext context)
        {
            _context = context;
        }

        public List<Opmerking> FindByBatterijId(int id)
        {
            return _context.Opmerkingen.Where(o => o.BatterijID == id)
                .OrderBy(o => o.ModDatum)
                .ToList();
        }
    }
}
