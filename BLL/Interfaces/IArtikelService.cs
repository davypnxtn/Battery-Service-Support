using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IArtikelService
    {
        List<Artikel> GetArtikels();
        Artikel FindById(int id);
    }
}
