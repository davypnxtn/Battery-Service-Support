using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public bool aktief { get; set; }
        public int GebruikerTypeID { get; set; }
        public GebruikerType GebruikerType { get; set; }
        public List<Batterij> Batterijen { get; set; }
        public List<Opmerking> Opmerkingen { get; set; }
    }
}
