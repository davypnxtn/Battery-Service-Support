using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IGebruikerRepository
    {
        List<Gebruiker> GetGebruikers();
        Gebruiker FindByNaam(string naam);
        Gebruiker FindById(int id);
    }
}
