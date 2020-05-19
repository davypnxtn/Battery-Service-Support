using DAL.Data;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ArtikelRepository : IArtikelRepository
    {
        private readonly DataContext _context;

        public ArtikelRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Opvragen artikels op artikelId -----
        public Artikel FindById(int id)
        {
            return _context.Artikels.Where(a => a.Id == id).Single();
        }

        // ----- Opvragen artikels op xjoArtikelId -----
        public Artikel FindByXjoArtikelId(int id)
        {
            return _context.Artikels.Where(a => a.XjoArtikelId == id).Single();
        }

        // ----- Opvragen alle Artikels -----
        public List<Artikel> GetArtikels()
        {
            return _context.Artikels.ToList();
        }
    }
}
