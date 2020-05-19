using Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IBatterijService
    {
        List<Batterij> FindByInstallatieId(int id);
        Batterij FindById(int id);
        Task<BatterijDetailViewModel> CreateBatterijDetailViewModel(int id);
        Batterij Add(Batterij nieuweBatterij, int artikelId, string locatie);
        Batterij Update(Batterij batterijChanges);
        List<Batterij> GetBatteries(bool isVervangen);
        Task<List<ListBatteriesViewModel>> CreateListBatteriesViewModel(string name, string date, bool isVervangen);
        Task<List<ListBatteriesViewModel>> CreateBatterieWarningList();
    }
}
