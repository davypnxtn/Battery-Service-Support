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
    public class BatterijController : Controller
    {
        private readonly IBatterijService service;

        public BatterijController(IBatterijService _service)
        {
            service = _service;
        }
        // GET: /<controller>/
        public IActionResult Detail(int id)
        {
            var batterijDetailVM = service.CreateBatterijDetailViewModel(id);
            return View(batterijDetailVM);
        }

        public IActionResult Edit(BatterijDetailViewModel vm)
        {
            var batterijDetailVM = vm;
            return View(batterijDetailVM);
        }
    }
}
