using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class BatterijController : Controller
    {
        private readonly IBatterijService service;
        private readonly IArtikelService artikelService;
        private readonly IOpmerkingService opmerkingService;

        public BatterijController(IBatterijService _service, IArtikelService _artikelService, IOpmerkingService _opmerkingService)
        {
            service = _service;
            artikelService = _artikelService;
            opmerkingService = _opmerkingService;
        }

        // Toont Detail pagina van de Batterij
        // GET: /<controller>/
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batterijDetailVM = service.CreateBatterijDetailViewModel((int)id);
            ViewData["Artikels"] = new SelectList(artikelService.GetArtikels(), "Id", "Naam");
                
            return View(batterijDetailVM);
        }

        //Updaten of Toevoegen Batterij en Toevoegen opmerking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(BatterijDetailViewModel viewModel)
        {
            int batterijId = 0;
            if (ModelState.IsValid)
            {
                if (viewModel.ArtikelId != 0)
                {
                    var batterij = service.Add(viewModel.Batterij, viewModel.ArtikelId, viewModel.Batterij.Locatie);
                    batterijId = batterij.Id;
                }
                else
                {
                    var batterij = service.Update(viewModel.Batterij);
                    batterijId = batterij.Id;
                }
                
                if (!string.IsNullOrWhiteSpace(viewModel.NieuweOpmerking))
                {
                    opmerkingService.Add(viewModel.NieuweOpmerking, batterijId);
                }
            }
            return RedirectToAction("Detail", "Installatie", new { id = viewModel.Batterij.InstallatieId });
        }
    }
}
