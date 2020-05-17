using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Utilities;

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
        //Task<List<ListBatteriesViewModel>> FindByDate(string date, bool isVervangen);
        //Task<List<ListBatteriesViewModel>> FindByName(string name, bool isVervangen);
    }
}
