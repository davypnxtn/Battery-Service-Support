using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IRelatieService
    {
        //List<Relatie> GetRelaties();
        Relatie FindById(int id);
        RelatieIndexViewModel FindByNaam(string naam);
        RelatieIndexViewModel FindByAdres(string adres);
        RelatieIndexViewModel GetRelaties();
        RelatieDetailViewModel CreateRelatieDetailViewModel(int id);
        RelatieInstallatieViewModel CreateRelatieInstallatieViewModel(int id);
    }
}
