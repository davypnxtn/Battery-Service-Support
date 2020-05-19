using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class LeveradresRepository : ILeveradresRepository
    {
        private readonly DataContext _context;

        public LeveradresRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Opvragen leveradressen op adres -----
        public List<Leveradres> FindByAdres(string adres)
        {
            return _context.Leveradressen.Where(l => l.Adres.Contains(adres))
                .Include(l => l.Gemeente)
                .Include(l => l.Relatie)
                .ToList();
        }

        // ----- Opvragen leveradressen op leveradresId -----
        public Leveradres FindById(int id)
        {
            return _context.Leveradressen.Where(l => l.Id == id)
                .Include(l => l.Gemeente)
                .Include(l => l.Relatie)
                .Single();
        }

        // ----- Opvragen leveradressen op relatieId -----
        public List<Leveradres> FindByRelatieId(int id)
        {
            return _context.Leveradressen.Where(l => l.RelatieId == id)
                .Include(l => l.Gemeente)
                .Include(l => l.Relatie)
                .ToList();
        }
    }
}
