using Model;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGebruikerTypeRepository
    {
        List<GebruikerType> GetGebruikerTypes();
        GebruikerType FindById(int id);
    }
}
