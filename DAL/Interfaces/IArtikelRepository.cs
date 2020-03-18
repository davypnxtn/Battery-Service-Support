using Model;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IArtikelRepository
    {
        List<Artikel> GetArtikels();
        Artikel FindById(int id);
        Artikel FindByXjoArtikelId(int id);
    }
}
