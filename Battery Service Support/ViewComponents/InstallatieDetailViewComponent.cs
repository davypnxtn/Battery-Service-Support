using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Battery_Service_Support.ViewComponents
{
    public class InstallatieDetailViewComponent : ViewComponent
    {
        private readonly IInstallatieService service;

        public InstallatieDetailViewComponent(IInstallatieService _service)
        {
            service = _service;
        }

        // ----- Weergeven viewcomponent batterijen van installatie -----
        public IViewComponentResult Invoke(InstallatieDetailViewModel model)
        {
            return View(model);
        }
    }
}
