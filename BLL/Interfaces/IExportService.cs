using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace BLL.Interfaces
{
    public interface IExportService
    {
        FileResult GeneratePdf(int id);
        string GenerateHtmlString(int id);
        List<ExportInstallationViewModel> FindInstallations(int id);
        PdfPreviewViewModel FindInstallationBatteries(int id);
    }
}
