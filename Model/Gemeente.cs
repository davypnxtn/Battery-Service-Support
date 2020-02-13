using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Gemeente
    {
        public int Id { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public DateTime ModDatum { get; set; }
        public int LandId { get; set; }
        public Land Land { get; set; }
        public List<Leveradres> Leveradressen { get; set; }
        public List<Relatie> Relaties { get; set; }
    }
}
