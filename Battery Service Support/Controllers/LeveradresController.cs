using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize(Policy = "ReadCustomersPolicy")]
        public IActionResult Detail(int id)
        {
            var leveradresDetailVM = service.CreateLeveradresDetailViewModel(id);
            return View(leveradresDetailVM);
        }
    }
}
