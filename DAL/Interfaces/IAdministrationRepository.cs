using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdministrationRepository
    {
        Task<IdentityResult> CreateRole(IdentityRole identityRole);
        List<IdentityRole> GetRoles();
        Task<IdentityRole> FindById(string id);
        Task<IdentityRole> FindByName(string name);
        Task<IdentityResult> EditRole(IdentityRole role);
        Task<IdentityResult> DeleteRole(IdentityRole role);
        Task<IList<Claim>> GetRoleClaims(IdentityRole role);
        Task<IdentityResult> RemoveRoleClaim(IdentityRole role, Claim claim);
        Task<IdentityResult> AddRoleClaim(IdentityRole role, Claim claim);
    }
}
