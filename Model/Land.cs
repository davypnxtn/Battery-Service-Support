using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Land
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime ModDatum { get; set; }
        public List<Gemeente> Gemeentes { get; set; }
    }
}
