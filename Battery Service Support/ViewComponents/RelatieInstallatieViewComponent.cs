using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battery_Service_Support.ViewComponents
{
    public class RelatieInstallatieViewComponent : ViewComponent
    {
        private readonly IRelatieService service;

        public RelatieInstallatieViewComponent(IRelatieService _service)
        {
            service = _service;   
        }

        // ----- Weergeven viewcomponent relatieadres indien relatie geen leveradressen heeft-----
        // Adres van Relate wordt getoond als leveradres
        public IViewComponentResult Invoke(int id)
        {
            var relatieInstallatieVM = service.CreateRelatieInstallatieViewModel(id);
            return View(relatieInstallatieVM);
        }
    }
}
