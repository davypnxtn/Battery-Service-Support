using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ViewModel
{
    public class RoleClaimsViewModel
    {
        public RoleClaimsViewModel()
        {
            Claims = new List<RoleClaim>();
        }

        public string RoleId { get; set; }
        public List<RoleClaim> Claims { get; set; }
    }
}
