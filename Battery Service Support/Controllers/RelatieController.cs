using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class RelatieController : Controller
    {

        private readonly IRelatieService service;

        public RelatieController(IRelatieService _service)
        {
            service = _service;
        }

        // ----- Index pagina dient om Relatie op te zoeken -----
        // Als de ingelogde gebruiker aan de administrator groep is toegewezen, zal er eerst gecontrolleerd worden
        // of er batterijen zijn die vervangen dienen te worden
        public IActionResult Index()
        {
            var relatieIndexVM = service.GetRelaties();
            return View(relatieIndexVM);
        }

        // ----- Dit is de pagina indien de gekozen relatie leveradres(sen) heeft -----
        public IActionResult Detail(int? id)
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

            var relatieDetailVM = service.CreateRelatieDetailViewModel((int)id);
            return View(relatieDetailVM);
        }

        // ----- Dit is de pagina indien gekozen relatie geen leveradres heeft -----
        // Adres van Relate wordt getoond als leveradres
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
        public IActionResult NaamSearch(RelatieIndexViewModel viewModel)
        {
            var relatieIndexVM = service.FindByNaam(viewModel.NaamSearch);
            return View("Index", relatieIndexVM);
        }

        // ----- Toont Index pagina Relaties gefilterd op adres of leveradres -----
        public IActionResult AdresSearch(RelatieIndexViewModel viewModel)
        {
            var relatieIndexVM = service.FindByAdres(viewModel.AdresSearch);
            return View("Index", relatieIndexVM);
        }

    }
}
