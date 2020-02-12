using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Batterij
    {
        public int BatterijID { get; set; }
        public string Naam { get; set; }
        public string? Locatie { get; set; }
        public DateTime Datum { get; set; }
        public string ArtikelNr { get; set; }
        public int? XjoBasisAppID { get; set; }
        public int? XjoBasisApp2Id { get; set; }
        public int? VervangenDoor { get; set; }
        public bool Vervangen { get; set; }
        public DateTime ModDatum { get; set; }
        public int InstallatieId { get; set; }
        public int GebruikerId { get; set; }
        public int ArtikelId { get; set; }
        public Installatie Installatie { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public Artikel Artikel { get; set; }

    }
}
