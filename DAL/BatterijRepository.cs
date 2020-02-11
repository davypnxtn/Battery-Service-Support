using DAL.Data;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{
    public class BatterijRepository : IBatterijRepository
    {
        private readonly DataContext _context;
        public BatterijRepository(DataContext context)
        {
            _context = context;
        }
        public List<Batterij> FindByInstallatieId(int id)
        {
            return _context.Batterijen.Where(b => b.InstallatieId == id).ToList();
        }
    }
}
