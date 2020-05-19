using DAL.Data;
using DAL.Interfaces;
using Model;
using System.Linq;

namespace DAL
{
    public class GemeenteRepository : IGemeenteRepository
    {
        private readonly DataContext _context;

        public GemeenteRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Opvragen gemeente op gemeenteId -----
        public Gemeente FindById(int id)
        {
            return _context.Gemeentes.Where(g => g.Id == id).Single();
        }
    }
}
