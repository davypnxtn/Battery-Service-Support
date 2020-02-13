using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Opmerking
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Opmerking")]
        public string Notitie { get; set; }
        [Required]
        public DateTime ModDatum { get; set; }
        public int BatterijID { get; set; }
        public int GebruikerID { get; set; }
        public Batterij Batterij { get; set; }
        public Gebruiker Gebruiker { get; set; }

    }
}
