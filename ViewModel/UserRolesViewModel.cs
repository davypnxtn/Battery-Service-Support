using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class UserRolesViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
        public string ErrorMessage { get; set; }
    }
}
