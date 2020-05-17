using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battery_Service_Support.ViewComponents
{
    public class RelatieDetailViewComponent : ViewComponent
    {
        private readonly IRelatieService service;

        public RelatieDetailViewComponent(IRelatieService _service)
        {
            service = _service;
        }

        // ----- Weergeven viewcomponent leveradressen relatie -----
        public IViewComponentResult Invoke(int id)
        {
            var relatieDetailVM = service.CreateRelatieDetailViewModel(id);
            return View(relatieDetailVM);
        }
    }
}
