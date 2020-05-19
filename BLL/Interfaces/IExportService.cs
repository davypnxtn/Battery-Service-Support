using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IExportService
    {
        Task<FileResult> GeneratePdf(int id);
        Task<string> GenerateHtmlString(int id);
        List<ExportInstallationViewModel> FindInstallations(int id);
        Task<ExportPdfViewModel> CreateExportPdfViewModel(int id);
        FileResult GenerateCsv(string date);
    }
}
