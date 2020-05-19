using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class BatterijRepository : IBatterijRepository
    {
        private readonly DataContext _context;
        public BatterijRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Toevoegen nieuwe batterij -----
        public Batterij Add(Batterij nieuweBatterij)
        {
            try
            {
                _context.Batterijen.Add(nieuweBatterij);
                _context.SaveChanges();
                return nieuweBatterij;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ----- Opvragen actieve batterijen op installatieId -----
        public List<Batterij> FindActiveByInstallatieId(int id)
        {
            return _context.Batterijen.Where(b => b.InstallatieId == id && b.Vervangen == false)
                .Include(b => b.Artikel)
                .Include(b => b.Installatie)
                .Include(b => b.User)
                .ToList();
        }

        // ----- Opvragen batterijen op batterijId -----
        public Batterij FindById(int id)
        {
            return _context.Batterijen.Where(b => b.Id == id)
                .Include(b => b.Artikel)
                .Include(b => b.Installatie)
                .Include(b => b.User)
                .Single();
        }

        // ----- Opvragen batterijen op installatieId -----
        public List<Batterij> FindByInstallatieId(int id)
        {
            return _context.Batterijen.Where(b => b.InstallatieId == id)
                .Include(b => b.Artikel)
                .Include(b => b.Installatie)
                .Include(b => b.User)
                .ToList();
        }

        // ----- Opvragen alle niet vervangen of vervangen batterijen -----
        public List<Batterij> GetBatteries(bool isVervangen)
        {
            return _context.Batterijen.Where(b => b.Vervangen == isVervangen)
                .Include(b => b.Artikel)
                .Include(b => b.Installatie)
                .Include(b => b.User)
                .ToList();
        }

        // ----- Wijzigen gegevens batterij -----
        public Batterij Update(Batterij batterijChanges)
        {
            try
            {
                _context.Batterijen.Update(batterijChanges);
                _context.SaveChanges();
                return batterijChanges;
            }
            catch (Exception)
            {
                throw;   
            }
        }

    }
}
