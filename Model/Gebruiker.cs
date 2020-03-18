using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Gebruiker
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Gebruikercode")]
        public string XjoGebruikerCode { get; set; }
        [Required]
        public string Naam { get; set; }
        public string? Email { get; set; }
        [Required]
        public bool Aktief { get; set; }
        public int GebruikerTypeId { get; set; }
        public GebruikerType GebruikerType { get; set; }
        public List<Batterij> Batterijen { get; set; }
        public List<Opmerking> Opmerkingen { get; set; }
    }
}
