using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IRelatieService
    {
        Relatie FindById(int id);
        //RelatieIndexViewModel FindByNaam(string naam, int? pageNumber);
        //RelatieIndexViewModel FindByAdres(string adres, int? pageNumber);
        RelatieIndexViewModel GetRelaties(string name, string address, int? pageNumber);
        RelatieDetailViewModel CreateRelatieDetailViewModel(int id);
        RelatieInstallatieViewModel CreateRelatieInstallatieViewModel(int id);
    }
}
