using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class BatterijDetailViewModel
    {
        public Batterij Batterij { get; set; }
        public string Opmerkingen { get; set; }
        public string NieuweOpmerking { get; set; }
        public ApplicationUser User { get; set; }
        public int RelatieId { get; set; }
        public int? LeveradresId { get; set; }
        public int ArtikelId { get; set; }
        public IEnumerable<SelectListItem> ArtikelSelectList { get; set; }

    }
}
