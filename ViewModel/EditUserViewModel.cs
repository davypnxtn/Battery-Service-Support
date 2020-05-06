using Battery_Service_Support.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [ValidEmailDomain(allowedDomain: "jojo.be",
            ErrorMessage = "Email domain must be jojo.be")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Gebruikercode")]
        public string XjoGebruikerCode { get; set; }

        [Required]
        public string Naam { get; set; }
        public bool Actief { get; set; }

        public string ErrorMessage { get; set; }

        public IList<string> Roles { get; set; }
    }
}
