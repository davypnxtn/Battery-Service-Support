using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel
{
    public class RoleUsersViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
        public string ErrorMessage { get; set; }
    }
}
