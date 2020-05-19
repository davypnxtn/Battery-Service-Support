using Model;
using System;

namespace BLL.Interfaces
{
    public interface IModDatumService
    {
        ModDatum GetModDatum();
        bool CompareModData(DateTime ModDatum, DateTime BatterijModDatum);
    }
}
