using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class BatterijDetailViewModel
    {
        public Batterij Batterij { get; set; }
        public List<Opmerking> Opmerkingen { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int RelatieId { get; set; }
        public int? LeveradresId { get; set; }
        public int InstallatieId { get; set; }
    }
}
