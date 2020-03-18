using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Relatie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Relatiecode")]
        public string XjoRelatieCode { get; set; }
        [Required]
        public string Naam { get; set; }
        public string? Roepnaam { get; set; }
        [Required]
        [Display(Name = "Straat")]
        public string Adres { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public int GemeenteId { get; set; }
        public Gemeente Gemeente { get; set; }
        public List<Leveradres> Leveradressen { get; set; }
        public List<Installatie> Installaties { get; set; }
    }
}
