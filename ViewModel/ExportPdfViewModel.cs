using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class ExportPdfViewModel
    {
        public ExportPdfViewModel()
        {
            Batterijen = new List<BatterijViewModel>();
            OudeBatterijen = new List<OudeBatterijViewModel>();
        }

        public DateTime RapportDatum { get; set; }
        public int InstallatieId { get; set; }
        public string InstallatieType { get; set; }
        public string RelatieCode { get; set; }
        public string RelatieNaam { get; set; }
        public string RelatieAdres { get; set; }
        public string RelatiePostcode { get; set; }
        public string RelatieGemeente { get; set; }
        public int LeveradresCode { get; set; }
        public string LeveradresNaam { get; set; }
        public string Leveradres { get; set; }
        public string LeveradresPostcode { get; set; }
        public string LeveradresGemeente { get; set; }
        public List<BatterijViewModel> Batterijen { get; set; }
        public List<OudeBatterijViewModel> OudeBatterijen { get; set; }


    }
}
