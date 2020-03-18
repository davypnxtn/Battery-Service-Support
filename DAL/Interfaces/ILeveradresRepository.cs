using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ILeveradresRepository
    {
        List<Leveradres> FindByRelatieId(int id);
        List<Leveradres> FindByAdres(string adres);
        Leveradres FindById(int id);
    }
}
