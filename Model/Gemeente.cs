using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Gemeente
    {
        public int Id { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        [Display(Name = "Gemeente")]
        public string Naam { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public int LandId { get; set; }
        public Land Land { get; set; }
        public List<Leveradres> Leveradressen { get; set; }
        public List<Relatie> Relaties { get; set; }
    }
}
