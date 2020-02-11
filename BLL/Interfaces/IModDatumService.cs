using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IModDatumService
    {
        ModDatum GetModDatum();
        bool CompareModData(DateTime ModDatum, DateTime BatterijModDatum);
    }
}
