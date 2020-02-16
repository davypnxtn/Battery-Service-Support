using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL.Interfaces
{
    public interface ILeveradresService
    {
        List<Leveradres> FindByKlantId(int id);
        Leveradres FindByAdres(string adres);
        LeveradresIndexViewModel CreateLeveradresIndexViewModel(int id);
    }
}
