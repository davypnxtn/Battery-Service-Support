using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IBatterijRepository
    {
        List<Batterij> FindByInstallatieId(int id);
        Batterij FindById(int id);
    }
}
