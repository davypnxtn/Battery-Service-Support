using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        
        // GET: /<controller>/ Zoekpagina relatie
        public IActionResult Index()
        {
            var relatieIndexVM = service.CreateRelatieIndexViewModel();
            return View(relatieIndexVM);
        }

        // GET: /<controller>/ pagina leveradressen gekozen relatie
        public IActionResult Detail(int id)
        {
            var relatieDetailVM = service.CreateRelatieDetailViewModel(id);
            return View(relatieDetailVM);
        }

        // GET: /<controller>/ pagina indien relatie geen leveradres heeft
        // toont facturatie adres als leveradres
        public IActionResult Installatie(int id)
        {
            var relatieInstallatieVM = service.CreateRelatieInstallatieViewModel(id);
            return View(relatieInstallatieVM); 
        }
    }
}
