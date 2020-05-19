using Model;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ILeveradresRepository
    {
        List<Leveradres> FindByRelatieId(int id);
        List<Leveradres> FindByAdres(string adres);
        Leveradres FindById(int id);
    }
}
