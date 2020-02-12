using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Opmerking
    {
        public int Id { get; set; }
        public string? Notitie { get; set; }
        public DateTime ModDatum { get; set; }
        public int InstallatieID { get; set; }
        public int GebruikerID { get; set; }
        public Installatie Installatie { get; set; }
        public Gebruiker Gebruiker { get; set; }

    }
}
