using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationRepository(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        public async Task<IdentityResult> CreateRole(IdentityRole identityRole)
        {
            return await roleManager.CreateAsync(identityRole);
        }

        public async Task<IdentityRole> FindById(string id)
        {
            return await roleManager.FindByIdAsync(id);
        }

        public List<IdentityRole> GetRoles()
        {
            return roleManager.Roles.ToList();
        }

        public async Task<IdentityResult> EditRole(IdentityRole role)
        {
            return await roleManager.UpdateAsync(role);
        }

        public async Task<IdentityResult> DeleteRole(IdentityRole role)
        {
            try
            {
                return await roleManager.DeleteAsync(role);
            }
            catch (DbUpdateException)
            {
                throw new Exception("Exception while deleting Role, there are Users assigned to this Role");
            }
        }

        public async Task<IList<Claim>> GetRoleClaims(IdentityRole role)
        {
            return await roleManager.GetClaimsAsync(role);
        }

        public async Task<IdentityResult> RemoveRoleClaim(IdentityRole role, Claim claim)
        {
            return await roleManager.RemoveClaimAsync(role, claim);
        }

        public async Task<IdentityResult> AddRoleClaim(IdentityRole role, Claim claim)
        {
            return await roleManager.AddClaimAsync(role, claim);
        }
    }
}
