using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRelatieRepository
    {
        List<Relatie> GetRelaties();
        IQueryable<Relatie> GetRelatiesIQ();
        Relatie FindById(int id);
        List<Relatie> FindByNaam(string naam);
        List<Relatie> FindByRoepnaam(string roepnaam);
        List<Relatie> FindByAdres(string adres);
    }
}
