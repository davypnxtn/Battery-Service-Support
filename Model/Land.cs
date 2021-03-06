﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Land
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public List<Gemeente> Gemeentes { get; set; }
    }
}
