using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRelatieRepository
    {
        List<Relatie> GetRelaties();
        Relatie FindById(int id);
        Relatie FindByNaam(string naam);
        Relatie FindByAdres(string adres);
    }
}
