using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Display(Name = "Rolnaam")]
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> Users { get; set; }
    }
}
