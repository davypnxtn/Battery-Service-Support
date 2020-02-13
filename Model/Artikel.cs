using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        public DateTime ModDatum { get; set; }
        public List<Batterij> Batterijen { get; set; }
    }
}
