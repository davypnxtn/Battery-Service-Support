using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Leveradres
    {
        public int Id { get; set; }
        public int LevAdrId { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public DateTime ModDatum { get; set; }
        public int RelatieId { get; set; }
        public int GemeenteId { get; set; }
        public Relatie Relatie { get; set; }
        public Gemeente Gemeente { get; set; }
        public List<Installatie> Installaties { get; set; }
    }
}
