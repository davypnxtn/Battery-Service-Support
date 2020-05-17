using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Utilities;

namespace ViewModel
{
    // Viewmodel voor Index view van Relatiecontroller
    public class RelatieIndexViewModel
    {
        public PaginatedList<Relatie> Relaties { get; set; }
        public string NaamSearch { get; set; }
        public string AdresSearch { get; set; }
    }
}
