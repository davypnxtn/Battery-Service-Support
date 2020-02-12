using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Relatie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string? Roepnaam { get; set; }
        public string Adres { get; set; }
        public DateTime ModDatum { get; set; }
        public int GemeenteId { get; set; }
        public Gemeente Gemeente { get; set; }
        public List<Leveradres> Leveradressen { get; set; }
        public List<Installatie> Installaties { get; set; }
    }
}
