using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Battery_Service_Support.ViewComponents
{
    public class LeveradresDetailViewComponent : ViewComponent
    {

        private readonly ILeveradresService service;

        public LeveradresDetailViewComponent( ILeveradresService _service)
        {
            service = _service;
        }

        public IViewComponentResult Invoke(int id)
        {
            var leveradresDetailVM = service.CreateLeveradresDetailViewModel(id);
            return View(leveradresDetailVM);
        }
    }
}
