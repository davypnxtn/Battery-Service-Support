using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class InstallatieRepository : IInstallatieRepository
    {
        private readonly DataContext _context;

        public InstallatieRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Opvragen installatie op installatieId -----
        public Installatie FindById(int id)
        {
            return _context.Installaties.Where(i => i.Id == id)
                .Include(i => i.InstallatieType)
                .Single();
        }

        // ----- Opvragen installaties op leveradresId -----
        public List<Installatie> FindByLeveradresId(int id)
        {
            return _context.Installaties.Where(i => i.LeveradresId == id)
                .Include(i => i.InstallatieType)
                .ToList();
        }

        // ----- Opvragen installaties op relatieId -----
        public List<Installatie> FindByRelatieId(int id)
        {
            return _context.Installaties.Where(i => i.RelatieId == id)
                .Include(i => i.InstallatieType)
                .ToList();
        }
    }
}
