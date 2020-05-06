using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace Battery_Service_Support.ViewComponents
{
    public class ListBatteriesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<ListBatteriesViewModel> model)
        {
            return View(model);
        }
    }
}
