using Model;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGebruikerRepository
    {
        List<Gebruiker> GetGebruikers();
        Gebruiker FindByNaam(string naam);
        Gebruiker FindById(int id);
        Gebruiker FindByCode(string code);
    }
}
