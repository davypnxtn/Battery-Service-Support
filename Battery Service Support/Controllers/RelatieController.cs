using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class RelatieController : Controller
    {

        private readonly IRelatieService service;
        private readonly IAuthorizationService authorizationService;

        public RelatieController(IRelatieService _service, IAuthorizationService _authorizationService)
        {
            service = _service;
            authorizationService = _authorizationService;
        }

        // ----- Index pagina dient om Relatie op te zoeken -----
        // Als de ingelogde gebruiker aan de administrator groep is toegewezen, zal er eerst gecontrolleerd worden
        // of er batterijen zijn die vervangen dienen te worden
        [HttpGet]
        public IActionResult Index(string name, string address, int? pageNumber)
        {
            //var authResult = await authorizationService.AuthorizeAsync(User, "WarningBatteriesPolicy");
            //if (authResult.Succeeded)
            //{
            //    return RedirectToAction("BatterieWarningList", "Batterij");
            //}

            ViewData["CurrentNameFilter"] = name;
            ViewData["CurrentAddressFilter"] = address;

            var relatieIndexVM = service.GetRelaties(name, address, pageNumber);
            return View(relatieIndexVM);
        }

        // ----- Dit is de actie indien de gekozen relatie leveradres(sen) heeft -----
        [HttpGet]
        [Authorize(Policy = "ReadCustomersPolicy")]
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var relatie = service.FindById((int)id);

            if (relatie == null)
            {
                return View("RelatieNotFound", id.Value);
            }

            //var relatieDetailVM = service.CreateRelatieDetailViewModel((int)id);
            return View((int)id);
        }

        // ----- Dit is de actie indien gekozen relatie geen leveradres heeft -----
        // Adres van Relate wordt getoond als leveradres
        [HttpGet]
        [Authorize(Policy = "ReadCustomersPolicy")]
        public IActionResult Installatie(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var relatie = service.FindById((int)id);

            if (relatie == null)
            {
                Response.StatusCode = 404;
                return View("RelatieNotFound", id.Value);
            }

            var relatieInstallatieVM = service.CreateRelatieInstallatieViewModel((int)id);
            return View(relatieInstallatieVM); 
        }

        // ----- Toont Index pagina Relaties gefilterd op naam of roepnaam -----
        //[HttpGet]
        //public IActionResult NaamSearch(RelatieIndexViewModel viewModel, int? pageNumber)
        //{
        //    var relatieIndexVM = service.FindByNaam(viewModel.NaamSearch, pageNumber);
        //    return View("Index", relatieIndexVM);
        //}

        // ----- Toont Index pagina Relaties gefilterd op adres of leveradres -----
        //[HttpGet]
        //public IActionResult AdresSearch(RelatieIndexViewModel viewModel, int? pageNumber)
        //{
        //    var relatieIndexVM = service.FindByAdres(viewModel.AdresSearch, pageNumber);
        //    return View("Index", relatieIndexVM);
        //}

    }
}
