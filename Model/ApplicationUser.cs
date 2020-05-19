using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
