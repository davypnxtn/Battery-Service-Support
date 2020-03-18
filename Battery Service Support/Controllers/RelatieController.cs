using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
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

        
        // GET: /<controller>/
        // Index pagina dient om Relatie op te zoeken
        public IActionResult Index()
        {
            var relatieIndexVM = service.GetRelaties();
            return View(relatieIndexVM);
        }

        // GET: /<controller>/
        // Dit is de pagina indien gekozen relatie wel een leveradres(sen) heeft
        public IActionResult Detail(int id)
        {
            var relatieDetailVM = service.CreateRelatieDetailViewModel(id);
            return View(relatieDetailVM);
        }

        // GET: /<controller>/ 
        // Dit is de pagina indien gekozen relatie geen leveradres heeft
        // Toont facturatie adres als leveradres
        public IActionResult Installatie(int id)
        {
            var relatieInstallatieVM = service.CreateRelatieInstallatieViewModel(id);
            return View(relatieInstallatieVM); 
        }

        //GET: Toont Index pagina Relaties gefilterd op naam of roepnaam
        public IActionResult NaamSearch(RelatieIndexViewModel viewModel)
        {
            var relatieIndexVM = service.FindByNaam(viewModel.NaamSearch);
            return View("Index", relatieIndexVM);
        }

        //GET: Toont Index pagina Relaties gefilterd op adres of leveradres
        public IActionResult AdresSearch(RelatieIndexViewModel viewModel)
        {
            var relatieIndexVM = service.FindByAdres(viewModel.AdresSearch);
            return View("Index", relatieIndexVM);
        }
    }
}
