using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IRelatieService
    {
        List<Relatie> GetKlanten();
        Relatie FindById(int id);
        Relatie FindByNaam(string naam);
        Relatie FindByAdres(string adres);
    }
}
