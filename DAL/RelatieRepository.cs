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
    public class RelatieRepository : IRelatieRepository
    {
        private readonly DataContext _context;

        public RelatieRepository(DataContext context)
        {
            _context = context;
        }

        public Relatie FindByAdres(string adres)
        {
            return _context.Relaties.Where(r => r.Adres == adres).Single();
        }

        public Relatie FindById(int id)
        {
            return _context.Relaties.Where(r => r.Id == id).Single();
        }

        public Relatie FindByNaam(string naam)
        {
            return _context.Relaties.Where(r => r.Naam == naam).Single();
        }

        public List<Relatie> GetRelaties()
        {
            return _context.Relaties
                .Include(r => r.Gemeente)
                .ToList();
        }
    }
}
