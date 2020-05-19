using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class OpmerkingRepository : IOpmerkingRepository
    {
        private readonly DataContext _context;

        public OpmerkingRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Toevoegen nieuwe opmerking -----
        public void Add(Opmerking opmerking)
        {
            try
            {
                _context.Opmerkingen.Add(opmerking);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ----- Opvragen opmerking op batterijId -----
        public List<Opmerking> FindByBatterijId(int? id)
        {
            return _context.Opmerkingen.Where(o => o.BatterijId == id)
                .Include(o => o.User)
                .OrderBy(o => o.ModDatum)
                .ToList();
        }
    }
}
