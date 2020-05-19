using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class InstallatieController : Controller
    {
        private readonly IInstallatieService service;

        public InstallatieController(IInstallatieService _service)
        {
            service = _service;
        }

        // ----- Weergeven alle batterijen van installatie -----
        [HttpGet]
        [Authorize(Policy = "ReadCustomersPolicy")]
        public IActionResult Detail(int id)
        {
            var installatieDetailVM = service.CreateInstallatieDetailViewModel(id);
            return View(installatieDetailVM);
        }
    }
}
