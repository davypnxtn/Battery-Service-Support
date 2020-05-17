using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModel;
using ViewModel.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class BatterijController : Controller
    {
        private readonly IBatterijService service;
        private readonly IOpmerkingService opmerkingService;

        public BatterijController(IBatterijService _service, IOpmerkingService _opmerkingService)
        {
            service = _service;
            opmerkingService = _opmerkingService;
        }

        // ----- Toont Detail pagina van de Batterij -----
        [HttpGet]
        [Authorize(Policy = "ReadCustomersPolicy")]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batterijDetailVM = await service.CreateBatterijDetailViewModel((int)id);
                
            return View(batterijDetailVM);
        }

        // ----- Updaten Locatie, toevoegen Batterij en toevoegen Opmerking -----
        // In deze Actie wordt zowel de update van de locatie, het aanmaken van een nieuwe opmerking,
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

        // ----- Lijst van actieve batterijen -----
        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> ListActiveBatteries(string name, string date, int? pageNumber)
        {
            bool isVervangen = false;
            int pageSize = 6;

            ViewData["CurrentNameFilter"] = name;
            ViewData["CurrentDateFilter"] = date;

            var model = await service.CreateListBatteriesViewModel(name, date, isVervangen);
            var pagedModel = PaginatedList<ListBatteriesViewModel>.Create(model, pageNumber ?? 1, pageSize);

            return View(pagedModel);
        }

        // ----- Lijst van reeds vervangen batterijen -----
        [HttpGet]
        [Authorize(Policy = "ListsBatteriesPolicy")]
        public async Task<IActionResult> ListReplacedBatteries(string name, string date, int? pageNumber)
        {
            bool isVervangen = true;
            int pageSize = 2;

            ViewData["CurrentNameFilter"] = name;
            ViewData["CurrentDateFilter"] = date;

            var model = await service.CreateListBatteriesViewModel(name, date, isVervangen);
            var pagedModel = PaginatedList<ListBatteriesViewModel>.Create(model, pageNumber ?? 1, pageSize);

            return View(pagedModel);
        }

        // ----- Lijst van batterijen die bijna aan vervanging toe zijn -----
        [HttpGet]
        public async Task<IActionResult> BatterieWarningList(int? pageNumber)
        {
            int pageSize = 6;

            var model = await service.CreateBatterieWarningList();
            if (model.Any())
            {
                var pagedModel = PaginatedList<ListBatteriesViewModel>.Create(model, pageNumber ?? 1, pageSize);
                return View(pagedModel);
            }
            return RedirectToAction("Index", "Relatie");
        }

        // ----- Zoek actieve batterijen op plaatsingsdatum -----
        //[HttpGet]
        //[Authorize(Policy = "ListsBatteriesPolicy")]
        //public async Task<IActionResult> FindActiveByDate(string date)
        //{
        //    bool isVervangen = false;
        //    var model = await service.FindByDate(date, isVervangen);
        //    return View("ListActiveBatteries", model);
        //}

        // ----- Zoek actieve batterijen op relatienaam -----
        //[HttpGet]
        //[Authorize(Policy = "ListsBatteriesPolicy")]
        //public async Task<IActionResult> FindActiveByName(string name)
        //{
        //    bool isVervangen = false;
        //    var model = await service.FindByName(name, isVervangen);
        //    return View("ListActiveBatteries", model);
        //}

        // ----- Zoek vervangen batterijen op vervangdatum -----
        //[HttpGet]
        //[Authorize(Policy = "ListsBatteriesPolicy")]
        //public async Task<IActionResult> FindReplacedByDate(string date)
        //{
        //    bool isVervangen = true;
        //    var model = await service.FindByDate(date, isVervangen);
        //    return View("ListReplacedBatteries", model);
        //}

        // ----- Zoek vervangen batterijen op relatienaam -----
        //[HttpGet]
        //[Authorize(Policy = "ListsBatteriesPolicy")]
        //public async Task<IActionResult> FindReplacedByName(string name)
        //{
        //    bool isVervangen = true;
        //    var model = await service.FindByName(name, isVervangen);
        //    return View("ListReplacedBatteries", model);
        //}
    }
}
