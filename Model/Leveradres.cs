﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Leveradres
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Leveradres id")]
        public int XjoLeveradresId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        [Display(Name = "Straat")]
        public string Adres { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public int RelatieId { get; set; }
        public int GemeenteId { get; set; }
        public Relatie Relatie { get; set; }
        public Gemeente Gemeente { get; set; }
        public List<Installatie> Installaties { get; set; }
    }
}
