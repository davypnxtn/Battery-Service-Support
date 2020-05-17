using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL.Interfaces
{
    public interface ILeveradresService
    {
        List<Leveradres> FindByRelatieId(int id);
        List<Leveradres> FindByAdres(string adres);
        Leveradres FindById(int id);
        LeveradresDetailViewModel CreateLeveradresDetailViewModel(int id);
    }
}
