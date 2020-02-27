using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IInstallatieService
    {
        List<Installatie> FindByLeveradresId(int id);
        List<Installatie> FindByRelatieId(int id);
    }
}
