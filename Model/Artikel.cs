using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Artikel
    {
        public int Id { get; set; }
        public string ArtikelNr { get; set; }
        public string Naam { get; set; }
        public DateTime ModDatum { get; set; }
        public List<Batterij> Batterijen { get; set; }
    }
}
