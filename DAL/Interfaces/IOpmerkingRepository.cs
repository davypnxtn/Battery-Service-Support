using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IOpmerkingRepository
    {
        List<Opmerking> FindByBatterijId(int? id);
        void Add(Opmerking opmerking);
    }
}
