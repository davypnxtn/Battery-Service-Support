using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IGebruikerService
    {
        List<Gebruiker> GetGebruikers();
        Gebruiker FindByNaam(string naam);
        Gebruiker FindById(int id);
        Gebruiker FindByCode(string code);
    }
}
