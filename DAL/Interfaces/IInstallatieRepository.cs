using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IInstallatieRepository
    {
        Installatie FindById(int id);
        List<Installatie> FindByLeveradresId(int id);
        List<Installatie> FindByRelatieId(int id);
    }
}
