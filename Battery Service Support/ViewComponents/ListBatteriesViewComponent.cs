﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViewModel;

namespace Battery_Service_Support.ViewComponents
{
    public class ListBatteriesViewComponent : ViewComponent
    {
        // ----- Weergeven viewcomponent lijst batterijen -----
        public IViewComponentResult Invoke(List<ListBatteriesViewModel> model)
        {
            return View(model);
        }
    }
}
