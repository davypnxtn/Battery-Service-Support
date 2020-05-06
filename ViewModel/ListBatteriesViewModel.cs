using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class ListBatteriesViewModel
    {
        [Display(Name = "Type batterij")]
        public string BatterijType { get; set; }
        [Display(Name = "Geplaatst in")]
        public string GeplaatstIn { get; set; }
        [Display(Name = "Datum plaatsing")]
        public DateTime PlaatsingsDatum { get; set; }
        [Display(Name = "Datum vervangen")]
        public DateTime VervangDatum { get; set; }
        [Display(Name = "Geplaatst door")]
        public string UserName { get; set; }
        [Display(Name = "Vervangen door")]
        public string VervangenDoor { get; set; }
        public int InstallatieId { get; set; }
        [Display(Name = "Installatie")]
        public string InstallatieType { get; set; }
        [Display(Name = "Relatie")]
        public string RelatieNaam { get; set; }
        [Display(Name = "Relatiecode")]
        public string RelatieCode { get; set; }
        [Display(Name = "Straat")]
        public string RelatieAdres { get; set; }
        [Display(Name = "Postcode")]
        public string RelatiePostcode { get; set; }
        [Display(Name = "Gemeente")]
        public string RelatieGemeente { get; set; }
        [Display(Name = "Leveradres")]
        public string LeveradresNaam { get; set; }
        [Display(Name = "Straat")]
        public string Leveradres { get; set; }
        [Display(Name = "Postcode")]
        public string LeveradresPostcode { get; set; }
        [Display(Name = "Gemeente")]
        public string LeveradresGemeente { get; set; }

    }
}
