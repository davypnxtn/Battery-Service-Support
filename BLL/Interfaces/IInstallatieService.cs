using Model;
using System.Collections.Generic;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IInstallatieService
    {
        Installatie FindById(int id);
        List<Installatie> FindByLeveradresId(int id);
        List<Installatie> FindByRelatieId(int id);
        InstallatieDetailViewModel CreateInstallatieDetailViewModel(int id);
    }
}
