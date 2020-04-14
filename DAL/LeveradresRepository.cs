using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class LeveradresRepository : ILeveradresRepository
    {
        private readonly DataContext _context;

        public LeveradresRepository(DataContext context)
        {
            _context = context;
        }

        public List<Leveradres> FindByAdres(string adres)
        {
            return _context.Leveradressen.Where(l => l.Adres.Contains(adres))
                .Include(l => l.Relatie)
                .ToList();
        }

        public Leveradres FindById(int id)
        {
            return _context.Leveradressen.Where(l => l.Id == id)
                .Include(l => l.Gemeente)
                .Single();
        }

        public List<Leveradres> FindByRelatieId(int id)
        {
            return _context.Leveradressen.Where(l => l.RelatieId == id)
                .Include(l => l.Gemeente)
                .ToList();
        }
    }
}
