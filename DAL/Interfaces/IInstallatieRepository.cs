using Model;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IInstallatieRepository
    {
        Installatie FindById(int id);
        List<Installatie> FindByLeveradresId(int id);
        List<Installatie> FindByRelatieId(int id);
    }
}
