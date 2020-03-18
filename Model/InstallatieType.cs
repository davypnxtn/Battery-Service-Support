using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class InstallatieType
    {
        public int Id { get; set; }
        [Required]
        public string InstalTypeCode { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public List<Installatie> Installaties { get; set; }
    }
}
