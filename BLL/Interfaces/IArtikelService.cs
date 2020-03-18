using Model;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IArtikelService
    {
        List<Artikel> GetArtikels();
        Artikel FindById(int id);
        Artikel FindByXjoArtikelId(int id);
    }
}
