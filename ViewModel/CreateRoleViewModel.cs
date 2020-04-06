using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Rolnaam")]
        public string RoleName { get; set; }
    }
}
