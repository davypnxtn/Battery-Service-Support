using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IOpmerkingService
    {
        List<Opmerking> FindByBatterijId(int? id);
        void Add(string notitie, int batterijId);
    }
}
