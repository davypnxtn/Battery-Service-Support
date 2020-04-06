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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModDatum { get; set; }
        public int BatterijId { get; set; }
        public string UserId { get; set; }
        //public int GebruikerId { get; set; }
        public Batterij Batterij { get; set; }
        public ApplicationUser User { get; set; }
        //public Gebruiker Gebruiker { get; set; }

    }
}
