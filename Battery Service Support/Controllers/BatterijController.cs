using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Authorize(Policy = "ReadCustomersPolicy")]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batterijDetailVM = await service.CreateBatterijDetailViewModel((int)id);
            ViewData["Artikels"] = new SelectList(artikelService.GetArtikels(), "Id", "Naam");
                
            return View(batterijDetailVM);
        }

        // ----- Updaten locatie  of Toevoegen Batterij en Toevoegen opmerking -----
        // In deze Action wordt zowel de update van de locatie, het aanmaken van een nieuwe opmerking,
        // als het vervangen van de Batterij afgehandeld.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EditBatteryPolicy")]
        public IActionResult Detail(BatterijDetailViewModel model)
        {
            int batterijId = 0;
            if (ModelState.IsValid)
            {
                if (model.ArtikelId != 0)
                {
                    var batterij = service.Add(model.Batterij, model.ArtikelId, model.Batterij.Locatie);
                    batterijId = batterij.Id;
                }
                else
                {
                    var batterij = service.Update(model.Batterij);
                    batterijId = batterij.Id;
                }
                
                if (!string.IsNullOrWhiteSpace(model.NieuweOpmerking))
                {
                    opmerkingService.Add(model.NieuweOpmerking, batterijId);
                }
            }
            return RedirectToAction("Detail", "Installatie", new { id = model.Batterij.InstallatieId });
        }

        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> ListActiveBatteries()
        {
            bool isVervangen = false;
            var model = await service.CreateListBatteriesViewModel(isVervangen);
            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> ListReplacedBatteries()
        {
            bool isVervangen = true;
            var model = await service.CreateListBatteriesViewModel(isVervangen);
            return View(model);
        }

        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> BatterieWarningList()
        {
            var model = await service.CreateBatterieWarningList();
            if (model.Any())
            {
                return View(model);
            }
            return RedirectToAction("Index", "Relatie");
        }

        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> FindActiveByDate(string date)
        {
            bool isVervangen = false;
            var model = await service.FindByDate(date, isVervangen);
            return View("ListActiveBatteries", model);
        }

        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> FindActiveByName(string name)
        {
            bool isVervangen = false;
            var model = await service.FindByName(name, isVervangen);
            return View("ListActiveBatteries", model);
        }

        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> FindReplacedByDate(string date)
        {
            bool isVervangen = true;
            var model = await service.FindByDate(date, isVervangen);
            return View("ListReplacedBatteries", model);
        }

        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> FindReplacedByName(string name)
        {
            bool isVervangen = true;
            var model = await service.FindByName(name, isVervangen);
            return View("ListReplacedBatteries", model);
        }
    }
}
