using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Batterij
    {
        public int Id { get; set; }
        [Display(Name = "Geplaatst in")]
        public string? GeplaatstIn { get; set; }
        public string? Locatie { get; set; }
        [Display(Name ="Informatie")]
        public string? Info { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Datum geplaatst")]
        public DateTime Datum { get; set; }
        [Display(Name ="Basisapplicatie id")]
        public int? XjoBasisAppId { get; set; }
        [Display(Name ="Basisapplicatie 2 id")]
        public int? XjoBasisApp2Id { get; set; }
        [Display(Name ="Vervangen door")]
        public int? VervangenDoor { get; set; }
        [Required]
        public bool Vervangen { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public int InstallatieId { get; set; }
        public int GebruikerId { get; set; }
        public int ArtikelId { get; set; }
        public Installatie Installatie { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Artikel Artikel { get; set; }
        public List<Opmerking> Opmerkingen { get; set; }

    }
}
