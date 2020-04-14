using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class ExportInstallationViewModel
    {
        public int InstallatieId { get; set; }
        public string InstallatieCode { get; set; }
        public string InstallatieType { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Gemeente { get; set; }
    }
}
