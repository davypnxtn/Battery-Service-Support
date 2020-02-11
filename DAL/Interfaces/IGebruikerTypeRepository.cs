using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IGebruikerTypeRepository
    {
        List<GebruikerType> GetGebruikerTypes();
        GebruikerType GetById(int id);
    }
}
