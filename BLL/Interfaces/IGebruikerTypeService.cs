using Model;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IGebruikerTypeService
    {
        List<GebruikerType> GetGebruikerTypes();
        GebruikerType GetById(int id);
    }
}
