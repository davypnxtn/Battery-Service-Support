using Model;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IOpmerkingRepository
    {
        List<Opmerking> FindByBatterijId(int? id);
        void Add(Opmerking opmerking);
    }
}
