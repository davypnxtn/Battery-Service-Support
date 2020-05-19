using DAL.Data;
using DAL.Interfaces;
using Model;
using System.Linq;

namespace DAL
{
    public class LandRepository : ILandRepository
    {
        private readonly DataContext _context;

        public LandRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Opvragen land op landId -----
        public Land FindById(int id)
        {
            return _context.Landen.Where(l => l.Id == id).Single();
        }
    }
}
