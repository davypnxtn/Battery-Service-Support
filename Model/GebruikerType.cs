using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class GebruikerType
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public List<Gebruiker> Gebruikers { get; set; }
    }
}
