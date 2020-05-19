using Model;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IOpmerkingService
    {
        List<Opmerking> FindByBatterijId(int? id);
        void Add(string notitie, int batterijId);
    }
}
