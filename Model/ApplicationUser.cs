using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Gebruikercode")]
        public string XjoGebruikerCode { get; set; }
        public string Naam { get; set; }
        public bool Aktief { get; set; }
    }
}
