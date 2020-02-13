using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Installatie
    {
        public int Id { get; set; }
        [Required]
        public string XjoInstallatieCode { get; set; }
        [Required]
        public DateTime ModDatum { get; set; }
        public int? LeveradresID { get; set; }
        public int InstallatieTypeID { get; set; }
        public int RelatieId { get; set; }
        public Leveradres Leveradres { get; set; }
        public InstallatieType InstallatieType { get; set; }
        public Relatie Relatie { get; set; }
        public List<Batterij> Batterijen { get; set; }
    }
}
