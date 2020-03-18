using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Batterij Add(Batterij nieuweBatterij)
        {
            try
            {
                _context.Batterijen.Add(nieuweBatterij);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return nieuweBatterij;
        }

        public List<Batterij> FindActiveByInstallatieId(int id)
        {
            return _context.Batterijen.Where(b => b.InstallatieId == id && b.Vervangen == false)
                .Include(b => b.Artikel)
                .Include(b => b.Installatie)
                .Include(b => b.Gebruiker)
                .ToList();
        }

        public Batterij FindById(int? id)
        {
            return _context.Batterijen.Where(b => b.Id == id)
                .Include(b => b.Artikel)
                .Include(b => b.Installatie)
                .Include(b => b.Gebruiker)
                .Single();
        }

        public List<Batterij> FindByInstallatieId(int id)
        {
            return _context.Batterijen.Where(b => b.InstallatieId == id)
                .Include(b => b.Artikel)
                .Include(b => b.Installatie)
                .Include(b => b.Gebruiker)
                .ToList();
        }

        public Batterij Update(Batterij batterijChanges)
        {
            try
            {
                _context.Batterijen.Update(batterijChanges);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;   
            }
            return batterijChanges;
            //Batterij batterij = _context.Batterijen.SingleOrDefault(b => b.Id == batterijChanges.Id);
            //if (batterij != null)
            //{
            //    batterij.Locatie = batterijChanges.Locatie;
            //}
        }

    }
}
