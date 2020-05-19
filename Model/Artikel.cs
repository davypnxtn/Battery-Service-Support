using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Artikel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Artikel id")]
        public int XjoArtikelId { get; set; }
        [Required]
        [Display(Name ="Artikel nummer")]
        public string ArtikelNr { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public List<Batterij> Batterijen { get; set; }
    }
}
