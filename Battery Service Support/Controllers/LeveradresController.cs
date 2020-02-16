using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class LeveradresController : Controller
    {
        private readonly ILeveradresService service;

        public LeveradresController(ILeveradresService _service)
        {
            service = _service;
        }
        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            var leveradresIndexVM = service.CreateLeveradresIndexViewModel(id);
            return View(leveradresIndexVM);
        }
    }
}
