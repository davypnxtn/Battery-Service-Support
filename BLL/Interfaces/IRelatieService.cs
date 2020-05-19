using Model;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IRelatieService
    {
        Relatie FindById(int id);
        RelatieIndexViewModel GetRelaties(string name, string address, int? pageNumber);
        RelatieDetailViewModel CreateRelatieDetailViewModel(int id);
        RelatieInstallatieViewModel CreateRelatieInstallatieViewModel(int id);
    }
}
