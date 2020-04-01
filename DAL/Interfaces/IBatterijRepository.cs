using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IBatterijRepository
    {
        List<Batterij> FindByInstallatieId(int id);
        List<Batterij> FindActiveByInstallatieId(int id);
        Batterij FindById(int id);
        Batterij Add(Batterij nieuweBatterij);
        Batterij Update(Batterij batterijChanges);
    }
}
