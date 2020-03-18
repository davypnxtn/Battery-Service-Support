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

        public List<Relatie> FindByAdres(string adres)
        {
            return _context.Relaties.Where(r => r.Adres.Contains(adres))
                .Include(r => r.Gemeente)
                .ToList();
        }

        public Relatie FindById(int id)
        {
            return _context.Relaties.Where(r => r.Id == id)
                .Include(r => r.Gemeente)
                .Single();
        }

        public List<Relatie> FindByNaam(string naam)
        {
            return _context.Relaties.Where(r => r.Naam.Contains(naam))
                .Include(r => r.Gemeente)
                .ToList();
        }

        public List<Relatie> FindByRoepnaam(string roepnaam)
        {
            return _context.Relaties.Where(r => r.Roepnaam.Contains(roepnaam))
                .Include(r => r.Gemeente)
                .ToList();
        }

        public List<Relatie> GetRelaties()
        {
            return _context.Relaties
                .Include(r => r.Gemeente)
                .ToList();
        }
    }
}
