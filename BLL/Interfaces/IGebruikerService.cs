using Model;
using System.Collections.Generic;

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
