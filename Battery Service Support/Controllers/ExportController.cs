using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class ExportController : Controller
    {
        private readonly IExportService service;
        private readonly IRelatieService relatieService;

        public ExportController(IExportService _service, IRelatieService _relatieService)
        {
            service = _service;
            relatieService = _relatieService;
        }

        public IActionResult ListCustomers(int? id)
        {
            if (id != null)
            {
                return RedirectToAction("ExportToPdf", new { id = (int)id });
            }

            var relatieIndexVM = relatieService.GetRelaties();
            return View(relatieIndexVM);
        }

        public IActionResult ListInstallations(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Relatie");
            }

            var model = service.FindInstallations((int)id);
            return View(model);
        }

        //[AllowAnonymous]
        //public IActionResult PdfPreview(int id)
        //{
        //    //var model = service.FindInstallationBatteries(id);
        //    //return View(model);
        //    FileResult fileResult = service.GeneratePdf((int)id);
        //    return fileResult;
        //}

        public async Task<IActionResult> ExportToPdf(int? id)
        {
            if (id != null)
            {
                FileResult fileResult = await service.GeneratePdf((int)id);
                return fileResult;
            }
            return RedirectToAction("ListCustomers");
        }
    }
}
