using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IRelatieService
    {
        List<Relatie> GetRelaties();
        Relatie FindById(int id);
        Relatie FindByNaam(string naam);
        Relatie FindByAdres(string adres);
        RelatieIndexViewModel CreateRelatieIndexViewModel();
        RelatieDetailViewModel CreateRelatieDetailViewModel(int id);
        RelatieInstallatieViewModel CreateRelatieInstallatieViewModel(int id);
    }
}
