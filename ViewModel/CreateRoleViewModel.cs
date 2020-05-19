using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Rolnaam")]
        public string RoleName { get; set; }
    }
}
