using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
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
            // test roleclaims
            
            //IdentityRole role = await roleManager.FindByIdAsync(id);
            //var result = await roleManager.AddClaimAsync(role, new Claim("Edit Role", "true"));
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

        public async Task<IList<Claim>> GetClaims(IdentityRole role)
        {
            return await roleManager.GetClaimsAsync(role);
        }

        public async Task<IdentityResult> DeleteRole(IdentityRole role)
        {
            return await roleManager.DeleteAsync(role);
        }
    }
}
