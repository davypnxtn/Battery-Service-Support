using DAL.Data;
using DAL.Interfaces;
using Model;
using System.Linq;

namespace DAL
{
    public class ModDatumRepository : IModDatumRepository
    {
        private readonly DataContext _context;

        public ModDatumRepository(DataContext context)
        {
            _context = context;
        }

        // ----- Opvragen moddatums -----
        public ModDatum GetModDatum()
        {
            return _context.ModData.Last();
        }
    }
}
