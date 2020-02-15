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

        // GET: /<controller>/
        public IActionResult Index()
        {
            var relatieIndexVM = service.CreateRelatieIndexViewModel();
            return View(relatieIndexVM);
        }

        public IActionResult Detail(int id)
        {
            var relatieDetailVM = service.CreateRelatieDetailViewModel(id);
            return View(relatieDetailVM);
        }
    }
}
