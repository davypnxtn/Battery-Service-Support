using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace Battery_Service_Support.ViewComponents
{
    public class InstallatieDetailViewComponent : ViewComponent
    {

        // ----- Weergeven viewcomponent batterijen van installatie -----
        public IViewComponentResult Invoke(InstallatieDetailViewModel model)
        {
            return View(model);
        }
    }
}
