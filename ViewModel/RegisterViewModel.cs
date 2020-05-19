using Battery_Service_Support.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain(allowedDomain: "jojo.be", 
            ErrorMessage = "Email domain must be jojo.be")]
        public string Email { get; set; }
         
        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Paswoord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig paswoord")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^[A-Z]{2}")]
        [StringLength(2)]
        [Required]
        [Display(Name = "Gebruikercode")]
        public string XjoGebruikerCode { get; set; }

        [Required]
        public string Naam { get; set; }
    }
}

