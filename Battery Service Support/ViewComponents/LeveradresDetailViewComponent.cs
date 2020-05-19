using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Battery_Service_Support.ViewComponents
{
    public class LeveradresDetailViewComponent : ViewComponent
    {

        private readonly ILeveradresService service;

        public LeveradresDetailViewComponent( ILeveradresService _service)
        {
            service = _service;
        }

        // ----- Weergeven viewcomponent installaties van leveradres -----
        public IViewComponentResult Invoke(int id)
        {
            var leveradresDetailVM = service.CreateLeveradresDetailViewModel(id);
            return View(leveradresDetailVM);
        }
    }
}
