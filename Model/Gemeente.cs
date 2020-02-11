using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Gemeente
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public string Naam { get; set; }
        public DateTime ModDatum { get; set; }
        public int LandId { get; set; }
        public Land Land { get; set; }
        public List<Leveradres> Leveradressen { get; set; }
        public List<Relatie> Relaties { get; set; }
    }
}
