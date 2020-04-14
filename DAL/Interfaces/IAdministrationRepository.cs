using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdministrationRepository
    {
        Task<IdentityResult> CreateRole(IdentityRole identityRole);
        List<IdentityRole> GetRoles();
        Task<IdentityRole> FindById(string id);
        Task<IdentityResult> EditRole(IdentityRole role);
        Task<IList<Claim>> GetClaims(IdentityRole role);
        Task<IdentityResult> DeleteRole(IdentityRole role);
    }
}
