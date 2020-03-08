using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battery_Service_Support.ViewComponents
{
    public class InstallatieDetailViewComponent : ViewComponent
    {
        private readonly IInstallatieService service;

        public InstallatieDetailViewComponent(IInstallatieService _service)
        {
            service = _service;
        }

        public IViewComponentResult Invoke(int id)
        {
            var installatieDetailVM = service.CreateInstallatieDetailViewModel(id);
            return View(installatieDetailVM);
        }
    }
}
