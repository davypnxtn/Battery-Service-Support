using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Installatie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Installatiecode")]
        public string XjoInstallatieCode { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public int? LeveradresId { get; set; }
        public int InstallatieTypeId { get; set; }
        public int RelatieId { get; set; }
        public Leveradres Leveradres { get; set; }
        public InstallatieType InstallatieType { get; set; }
        public Relatie Relatie { get; set; }
        public List<Batterij> Batterijen { get; set; }
    }
}
