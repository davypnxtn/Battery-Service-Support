﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Battery_Service_Support.Controllers
{
    public class InstallatieController : Controller
    {
        private readonly IInstallatieService service;

        public InstallatieController(IInstallatieService _service)
        {
            service = _service;
        }

        // GET: /<controller>/
        public IActionResult Detail(int id)
        {
            var installatieDetailVM = service.CreateInstallatieDetailViewModel(id);
            return View(installatieDetailVM);
        }
    }
}