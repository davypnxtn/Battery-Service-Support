using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        // ----- Index pagina om Relatie op te zoeken -----
        [HttpGet]
        public IActionResult Index(string name, string address, int? pageNumber)
        {
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
    }
}
